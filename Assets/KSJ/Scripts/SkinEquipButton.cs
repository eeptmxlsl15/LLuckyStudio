using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkinEquipButton : MonoBehaviour
{
	// Start is called before the first frame update
	public List<Button> buttons = new List<Button>();

	void Start()
	{
		CollectAllButtons();
	}

	void CollectAllButtons()
	{
		// 현재 게임 오브젝트와 모든 자식 오브젝트에서 버튼 컴포넌트를 찾아서 리스트에 추가
		Button[] foundButtons = GetComponentsInChildren<Button>(true);

		for (int i = 0; i < foundButtons.Length; i++)
		{
			int index = i; // 캡처하기 위해 새 변수 생성
			Debug.Log("adad");
			foundButtons[i].onClick.AddListener(() => OnClickSkinEquip(index));
			buttons.Add(foundButtons[i]);
		}

		//장착 여부를 데이터매니져가 알아야함
		//데이터 매니져의 아이디를 가져와서 그 순서의 버튼을 비활성화 시킴
	}

	public void OnClickSkinEquip(int value)
	{
		DataManager.Instance.skinID = value;

		foreach (Button button in buttons)
		{
			button.interactable = true;
		}

		buttons[value].interactable = false;

	}

}