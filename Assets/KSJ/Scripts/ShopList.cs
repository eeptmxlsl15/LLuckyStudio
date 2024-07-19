using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopList : MonoBehaviour
{
	public static ShopList Instance { get; private set; }
	public int resetCost;

	[Header("Item Prefabs")]
	public List<GameObject> itemPrefabs; // 여러 아이템 프리팹 리스트

	[Header("Spawn Points")]
	public List<Transform> spawnPoints; // 아이템을 표시할 위치 리스트

	private List<GameObject> spawnedItems = new List<GameObject>(); // 생성된 아이템을 추적하기 위한 리스트

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			PickRandomItems();
			DisplayRandomItems();
		}
	}

	public void DisplayRandomItems()
	{
		// 부모 오브젝트의 localScale을 일시적으로 Vector3(1,1,1)로 설정
		Vector3 originalScale = transform.parent.localScale;
		transform.parent.localScale = new Vector3(1, 1, 1);

		// 기존에 생성된 아이템이 있다면 제거
		foreach (var item in spawnedItems)
		{
			Destroy(item);
		}
		spawnedItems.Clear();

		// 아이템 프리팹 중 랜덤하게 2개 선택
		List<int> chosenIndices = DataManager.Instance.resetItemID;

		// 선택한 아이템을 특정 위치에 생성
		for (int i = 0; i < chosenIndices.Count; i++)
		{
			int index = chosenIndices[i];
			GameObject itemPrefab = itemPrefabs[index];

			Transform spawnPoint = spawnPoints[i];
			Debug.Log(spawnPoint.localPosition.x + spawnPoint.localPosition.y);
			GameObject spawnedItem = Instantiate(itemPrefab, transform);

			// localPosition을 사용하여 정확한 위치 설정
			spawnedItem.transform.localPosition = spawnPoint.localPosition;
			spawnedItem.SetActive(true);
			spawnedItems.Add(spawnedItem);
		}

		// 원래의 localScale로 되돌림
		transform.parent.localScale = originalScale;
	}

	public void OnClickIngameReset()
	{
		if (DataManager.Instance.sushi - resetCost < 0)
		{
			return;
			//실패 사운드
			//3번째에도 안되게 해야함
			//시간이 12시일때 
		}
		PickRandomItems();
		DataManager.Instance.sushi -= resetCost;
		DisplayRandomItems();
	}

	public void PickRandomItems()//데이터매니져에 리셋 아이템 리스트를 랜덤하게 바꿈
	{
		for (int i = 0; i < spawnPoints.Count; i++) //아이템의 수
		{
			int randomIndex = Random.Range(0, itemPrefabs.Count); //아이템의 종류
			if (!DataManager.Instance.resetItemID.Contains(randomIndex))
			{
				DataManager.Instance.resetItemID[i] = randomIndex;
			}

			
		}
	}

	public void OnClickContent()
	{
		transform.parent.localScale = new Vector3(1, 1, 1);
		DisplayRandomItems();
	}
}