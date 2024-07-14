using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopItem : MonoBehaviour
{
	public int moneyCost;//유료 재화
	public int fishCost;
	public int cannedFoodCost;
	public int quantity;
	public int itemID;
	public bool alreadyBuy;
	public GameObject isBuyUI;
	public GameObject itemPrefab; // 아이템 프리팹을 저장할 변수
	public Transform contentTransform; // 프리팹 아이템을 넣을 부모 Transform
	public Button OverlayButton;//다른 곳을 클릭하면 isBuyUI가 꺼지게 하는 버튼
	
	public TMP_Text costText;
	public TMP_Text quantityText;
	private void Start()
	{
		costText = transform.Find("Button/Fish Cost").GetComponent<TMP_Text>();
		quantityText = transform.Find("Button/Quantity").GetComponent<TMP_Text>();
		OverlayButton = GameObject.Find("/Canvas/Overlay Button").GetComponent<Button>();
		

		//this.transform.localScale = new Vector3(1, 1, 1);
		itemPrefab = transform.gameObject;
		// isBuyUI를 찾음
		isBuyUI = GameObject.Find("/Canvas/Is Buy");
		if (isBuyUI == null)
		{
			Debug.LogError("IsBuy UI를 찾을 수 없습니다. 이름이 정확한지 확인하세요.");
		}

		// isBuyUI 안의 Content를 찾음
		contentTransform = isBuyUI.transform.Find("Contents");
		if (contentTransform == null)
		{
			Debug.LogError("Contents 오브젝트를 찾을 수 없습니다. isBuyUI 안에 Content 오브젝트를 추가하세요.");
		}

		//isBuyUI.transform.localScale = new Vector3(0, 0, 0); // 초기에는 비활성화
		itemPrefab = transform.gameObject;
		UpdateText();
	}
	private void Update()
	{
	}

	public void OnClick()
	{
		if (DataManager.Instance.fish - fishCost < 0)
			return;
			Debug.Log("클릭됨");
		// isBuyUI를 활성화하고 위치를 고정된 위치로 설정
		isBuyUI.transform.localScale = new Vector3(1, 1, 1);
		OverlayButton.transform.localScale = new Vector3(1, 1, 1);

		// 기존에 생성된 아이템이 있다면 제거
		foreach (Transform child in contentTransform)
		{
			Destroy(child.gameObject);
		}

		// 클릭된 아이템 프리팹을 contentTransform 안에 생성
		GameObject spawnedItem = Instantiate(itemPrefab, contentTransform,transform.parent);
		RectTransform spawnedItemRect = spawnedItem.GetComponent<RectTransform>();
		if (spawnedItemRect != null)
		{
			Vector3 position = spawnedItemRect.localPosition;
			position.x = 0;
			position.y = 40;
			spawnedItemRect.localPosition = position;
		}
		Button buyButton = isBuyUI.transform.Find("Is Buy Button").GetComponent<Button>();
		buyButton.onClick.RemoveAllListeners();
		buyButton.onClick.AddListener(() => IsBuy(itemID));
	}

	public void IsBuy(int _itemID)
	{

		

		switch (_itemID)
		{
			case 1: // 통조림

				Debug.Log("여기");
				DataManager.Instance.fish -= fishCost;
				DataManager.Instance.cannedFood += quantity;
				transform.gameObject.SetActive(false);
				break;
			case 2: // 은방울
				
				DataManager.Instance.fish -= fishCost;
				DataManager.Instance.silverMarble += quantity;
				DataManager.Instance.isBuyItem2 = false;
				transform.gameObject.SetActive(false);
				break;
			case 3: // 금방울
				
				DataManager.Instance.fish -= fishCost;
				DataManager.Instance.goldMarble += quantity;
				DataManager.Instance.isBuyItem3 = false;
				transform.gameObject.SetActive(false);
				break;
			case 4: // 부활권
				
				DataManager.Instance.fish -= fishCost;
				DataManager.Instance.resurrection += quantity;
				DataManager.Instance.isBuyItem4 = false;
				transform.gameObject.SetActive(false);
				break;

			case 5: //유료 재화
			case 6:
			case 7:
				DataManager.Instance.money -= moneyCost;
				DataManager.Instance.cannedFood += quantity;
				break;
			case 8:
			case 9:
			case 10:

				DataManager.Instance.cannedFood -= cannedFoodCost;
				DataManager.Instance.fish += quantity;
				break;

		}

		
		
		isBuyUI.transform.localScale = new Vector3(0, 0, 0);
		OverlayButton.transform.localScale = new Vector3(0, 0, 0);

	}

	public void UpdateText()
	{
		quantityText.text = "" + quantity;
		costText.text = "Fish : "+fishCost;
		if (itemID == 5 || itemID == 6 || itemID == 7)
			costText.text = "Money : "+moneyCost;
		else if (itemID > 7)
			costText.text = "Canned Food : "+cannedFoodCost;
	}
}