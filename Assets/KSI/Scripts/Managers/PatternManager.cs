using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
	public List<GameObject> patterns; // 다양한 패턴 프리팹 리스트
	public float spawnDistance = 20.0f; // 패턴 생성 거리
	public int maxPatterns = 5; // 최대 활성 패턴 수

	private List<GameObject> activePatterns = new List<GameObject>();
	private Transform playerTransform;
	private float nextSpawnZ;

	private void Start()
	{
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		nextSpawnZ = playerTransform.position.z + spawnDistance;

		for (int i = 0; i < maxPatterns; i++)
		{
			SpawnPattern();
		}
	}

	private void Update()
	{
		if (playerTransform.position.z > nextSpawnZ - (maxPatterns * spawnDistance))
		{
			SpawnPattern();
			DeletePattern();
		}
	}

	private void SpawnPattern()
	{
		GameObject pattern = Instantiate(patterns[Random.Range(0, patterns.Count)], Vector3.forward * nextSpawnZ, Quaternion.identity);
		activePatterns.Add(pattern);
		nextSpawnZ += spawnDistance;
	}

	private void DeletePattern()
	{
		if (activePatterns.Count > maxPatterns)
		{
			Destroy(activePatterns[0]);
			activePatterns.RemoveAt(0);
		}
	}
}
