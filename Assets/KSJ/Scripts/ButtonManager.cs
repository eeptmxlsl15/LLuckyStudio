using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
	public List<Button> buttons; // 모든 버튼을 리스트로 관리
	public List<GameObject> uiWindows; // 모든 UI 창을 리스트로 관리

	private Dictionary<Button, GameObject> buttonToUIMap = new Dictionary<Button, GameObject>();

	private void Start()
	{
		// 버튼과 UI 창을 매핑
		for (int i = 0; i < buttons.Count; i++)
		{
			buttonToUIMap.Add(buttons[i], uiWindows[i]);
			buttons[i].onClick.AddListener(() => OnButtonClick(buttons[i]));
		}
	}

	private void OnButtonClick(Button clickedButton)
	{
		// 클릭된 버튼과 관련된 UI 창을 가져옴
		GameObject clickedUIWindow = buttonToUIMap[clickedButton];

		// 모든 UI 창을 숨김
		foreach (var uiWindow in uiWindows)
		{
			uiWindow.transform.localScale = Vector3.zero;
		}

		// 클릭된 버튼과 관련된 UI 창을 표시
		clickedUIWindow.transform.localScale = Vector3.one;
	}


}
