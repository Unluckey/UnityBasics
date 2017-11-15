using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffect : MonoBehaviour {
	[Range(0.005f,0.1f)]
	public float springConstant = 0.01f;
	[Range(0.001f,0.2f)]
	public float damping = 0.04f;
	[Range(0.01f,0.05f)]
	public float spread = 0.05f;
	public float z = -1f;

	public float startX = -3f;
	public float startWidth = 2.9f;
	public float startTop = -2.2f;
	public float startBottom = -2.4f;

	float[] xpositions;
	float[] ypositions;
	float[] velocities;
	float[] accelerations;
	LineRenderer Body;

	GameObject[] meshObjects;
	Mesh[] meshes;

	//GameObject[] colliders;
	GameObject wCollider;

	float baseHeight;
	float left;
	float bottom;

	public GameObject splash;

	public Material mat;

	public GameObject waterMesh;

	void Start(){
		SpawnWater(startX,startWidth,startTop,startBottom);
	}
	public void SpawnWater (float left, float width, float top, float bottom){
		int edgeCount = Mathf.RoundToInt (width)*25;
		int nodeCount = edgeCount + 1;

		Body = gameObject.AddComponent<LineRenderer>();

		Body.material = mat;

		Body.material.renderQueue = 1000;

		Body.positionCount = nodeCount;
		Body.SetWidth(0.01f, 0.01f);

		xpositions = new float[nodeCount];
		ypositions = new float[nodeCount];
		velocities = new float[nodeCount];
		accelerations = new float[nodeCount];

		meshObjects = new GameObject[edgeCount];
		meshes = new Mesh[edgeCount];
		//colliders = new GameObject[edgeCount]
		baseHeight = top;
		this.bottom = bottom;
		this.left = left;

		for (int i = 0; i < nodeCount; i++)
		{
			ypositions[i] = top;
			xpositions[i] = left + width * i / edgeCount;
			accelerations[i] = 0;
			velocities[i] = 0;
			Body.SetPosition(i, new Vector3(xpositions[i], ypositions[i], z));
		}

		for (int i = 0; i < edgeCount; i++) {
			meshes [i] = new Mesh ();
			Vector3[] Vertices = new Vector3[4];
			Vertices[0] = new Vector3(xpositions[i], ypositions[i], z);
			Vertices[1] = new Vector3(xpositions[i + 1], ypositions[i + 1], z);
			Vertices[2] = new Vector3(xpositions[i], bottom, z);
			Vertices[3] = new Vector3(xpositions[i+1], bottom, z);

			Vector2[] UVs = new Vector2[4];
			UVs[0] = new Vector2(0, 1);
			UVs[1] = new Vector2(1, 1);
			UVs[2] = new Vector2(0, 0);
			UVs[3] = new Vector2(1, 0);

			int[] tris = new int[6] { 0, 1, 3, 3, 2, 0 };

			meshes[i].vertices = Vertices;
			meshes[i].uv = UVs;
			meshes[i].triangles = tris;

			meshObjects [i] = Instantiate (waterMesh, Vector3.zero, Quaternion.identity) as GameObject;
			meshObjects [i].GetComponent<MeshFilter> ().mesh = meshes [i];
			meshObjects [i].transform.parent = transform;
			/*
			colliders [i] = new GameObject ();
			colliders[i].name = "Trigger";
			colliders [i].AddComponent<BoxCollider2D> ();
			colliders [i].transform.parent = transform;
			colliders [i].transform.position = new Vector3 (left + width * (i + 0.5f) / edgeCount,(top+bottom)/2-0.05f, 0);
			colliders[i].transform.localScale = new Vector3(width/edgeCount,top-bottom,1);
			colliders[i].GetComponent<BoxCollider2D>().isTrigger = true;

			colliders[i].AddComponent<WaterDetector>();*/
		}
		wCollider = new GameObject();
		wCollider.name = "Trigger";
		wCollider.AddComponent<BoxCollider2D> ();
		wCollider.transform.parent = transform;
		wCollider.transform.position = new Vector3 (-width/ 2, (top + bottom) / 2, 0);
		wCollider.transform.localScale = new Vector3 (width, top - bottom, 1);
		wCollider.GetComponent<BoxCollider2D>().isTrigger = true;

		wCollider.AddComponent<WaterDetector> ();
	}

	public void Splash(float xpos ,float velocity){
		if (xpos >= xpositions [0] && xpos <= xpositions [xpositions.Length - 1]) {
			//Offset the x position to be the distance from the left side
			xpos -= xpositions [0];

			//Find which spring we're touching
			int index = Mathf.RoundToInt ((xpositions.Length - 1) * (xpos / (xpositions [xpositions.Length - 1] - xpositions [0])));

			//Add the velocity of the falling object to the spring
			velocities [index] += velocity;


			float lifetime = 0.4f + Mathf.Abs(velocity)*0.07f;
			splash.GetComponent<ParticleSystem>().startSpeed = 2f + 2*Mathf.Pow(Mathf.Abs(velocity),0.5f);
			splash.GetComponent<ParticleSystem>().startSpeed = 3f + 2 * Mathf.Pow(Mathf.Abs(velocity), 0.5f);
			splash.GetComponent<ParticleSystem>().startLifetime = lifetime;

			Vector3 position = new Vector3(xpositions[index],ypositions[index],5);
			Quaternion rotation = Quaternion.LookRotation (new Vector3 (xpositions [Mathf.FloorToInt (xpositions.Length / 2)], baseHeight + 8, 5) - position);
				
			GameObject splish = Instantiate(splash,position,rotation) as GameObject;
			Destroy(splish, lifetime+0.3f);
		}
	}

	void UpdateMeshes(){
		for (int i = 0; i < meshes.Length; i++) {
			Vector3[] Vertices = new Vector3[4];
			Vertices[0] = new Vector3(xpositions[i], ypositions[i], z);
			Vertices[1] = new Vector3(xpositions[i+1], ypositions[i+1], z);
			Vertices[2] = new Vector3(xpositions[i], bottom, z);
			Vertices[3] = new Vector3(xpositions[i+1], bottom, z);

			meshes [i].vertices = Vertices;
		}
	}

	void FixedUpdate(){
		for (int i = 0; i < xpositions.Length; i++) {
			float force = springConstant * (ypositions[i] - baseHeight) + velocities[i]*damping ;
			accelerations[i] = -force;
			ypositions[i] += velocities[i];
			velocities[i] += accelerations[i];
			Body.SetPosition(i, new Vector3(xpositions[i], ypositions[i], z));
		}
		float[] leftDeltas = new float[xpositions.Length];
		float[] rightDeltas = new float[xpositions.Length];

		for (int j = 0; j < 40; j++) {
			for (int i = 0; i < xpositions.Length; i++) {
				//We check the heights of the nearby nodes, adjust velocities accordingly, record the height differences
				if (i > 0) {
					leftDeltas [i] = spread * (ypositions [i] - ypositions [i - 1]);
					velocities [i - 1] += leftDeltas [i];
				}
				if (i < xpositions.Length - 1) {
					rightDeltas [i] = spread * (ypositions [i] - ypositions [i + 1]);
					velocities [i + 1] += rightDeltas [i];
				}
			}
		
			//Now we apply a difference in position
			for (int i = 0; i < xpositions.Length; i++) {
				if (i > 0)
					ypositions [i - 1] += leftDeltas [i];
				if (i < xpositions.Length - 1)
					ypositions [i + 1] += rightDeltas [i];
			}
		}
			UpdateMeshes();
	}
}
