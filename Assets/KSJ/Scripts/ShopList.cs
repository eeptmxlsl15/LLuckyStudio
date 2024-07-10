using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopList : MonoBehaviour
{
	public int resetCost;
	[Header("Item Prefabs")]
	public List<GameObject> itemPrefabs; // 여러 아이템 프리팹 리스트

	[Header("Spawn Points")]
	public List<Transform> spawnPoints; // 아이템을 표시할 위치 리스트

	private List<GameObject> spawnedItems = new List<GameObject>(); // 생성된 아이템을 추적하기 위한 리스트

	void Start()
	{
		transform.parent.localScale = new Vector3(1, 1, 1);//0에서 스폰 위치가 이상하게 지정되기 때문
		DisplayRandomItems();
		transform.parent.localScale = new Vector3(0, 0, 0);
	}
	


	private void DisplayRandomItems()
	{
		// 기존에 생성된 아이템이 있다면 제거
		foreach (var item in spawnedItems)
		{
			Destroy(item);
		}
		spawnedItems.Clear();

		// 아이템 프리팹 중 랜덤하게 2개 선택
		List<int> chosenIndices = GetRandomIndices(itemPrefabs.Count, 2);

		// 선택한 아이템을 특정 위치에 생성
		for (int i = 0; i < chosenIndices.Count; i++)
		{
			int index = chosenIndices[i];
			GameObject itemPrefab = itemPrefabs[index];
			
			Transform spawnPoint = spawnPoints[i];
			GameObject spawnedItem = Instantiate(itemPrefab, spawnPoint.position, spawnPoint.rotation, transform);
			spawnedItem.transform.SetParent(transform, false);
			spawnedItem.SetActive(true);
			spawnedItems.Add(spawnedItem);
		}
		
	}

	private List<int> GetRandomIndices(int listCount, int itemCount)
	{
		List<int> indices = new List<int>();
		while (indices.Count < itemCount)
		{
			int randomIndex = Random.Range(0, listCount);
			if (!indices.Contains(randomIndex))
			{
				indices.Add(randomIndex);
			}
		}
		return indices;
	}

	public void OnClickIngameReset(){
		if (DataManager.Instance.fish - resetCost < 0)
		{
			return;
			//실패 사운드
		}

		DataManager.Instance.fish -= resetCost;
		DisplayRandomItems();
	}
}