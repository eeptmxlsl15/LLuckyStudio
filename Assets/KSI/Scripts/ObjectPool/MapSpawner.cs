using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
	[SerializeField] private GameObject[] prefabs;
	[SerializeField] private Transform spawnPoint;
	[SerializeField] private float spawnInterval = 3.0f; 

	private float timeSinceLastSpawn;

	private void Update()
	{
		timeSinceLastSpawn += Time.deltaTime;

		if (timeSinceLastSpawn >= spawnInterval)
		{
			SpawnRandomPrefab();
			timeSinceLastSpawn = 0f;
		}
	}

	private void SpawnRandomPrefab()
	{
		int randomIndex = Random.Range(0, prefabs.Length);
		GameObject selectedPrefab = prefabs[randomIndex];

		GameObject instance = Instantiate(selectedPrefab);
		instance.transform.SetParent(spawnPoint, true);

		instance.transform.localPosition = Vector3.zero;
		instance.transform.localRotation = Quaternion.identity;
	}
}
