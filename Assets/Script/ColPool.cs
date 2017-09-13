using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColPool : MonoBehaviour {
	public int colPoolSize = 5;
	public float spawnRate = 4f;
	private GameObject[] cols;
	public GameObject columPrefab;
	public float columnMin = -1f;
	public float columnMax = 3.5f;
	private float spawnXPosition = 10f;
	private int currentColum = 0;

	private Vector2 objectPoolPosition = new Vector2 (-15f, -25f);
	private float timesinceLastSpawned;

	// Use this for initialization
	void Start () {
		cols = new GameObject[colPoolSize];
		for (int i = 0; i < colPoolSize; i++) {
			cols [i] = (GameObject)Instantiate (columPrefab,objectPoolPosition, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		timesinceLastSpawned += Time.deltaTime;
		if (GameControl.instance.gameOver == false && timesinceLastSpawned >= spawnRate) {
			timesinceLastSpawned = 0;
			float spawnYPosition = Random.Range (columnMin, columnMax);
			cols [currentColum].transform.position = new Vector2 (spawnXPosition,spawnYPosition);
			currentColum++;
			if (currentColum >= colPoolSize)
				currentColum = 0;

		}
			
	}
}
