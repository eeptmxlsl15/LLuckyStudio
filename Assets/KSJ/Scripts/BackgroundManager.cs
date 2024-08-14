using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
	// 슬롯의 배경 오브젝트 (스프라이트가 변경될 오브젝트)
	public Image background;

	// 슬롯의 자식 오브젝트들 중 버튼들
	public Button[] buttons;

	// 버튼별로 교체할 스프라이트들
	public Sprite[] sprites;

	// 현재 선택된 버튼의 인덱스 (상태를 저장하기 위해)
	private int selectedButtonIndex = -1;

	private void Start()
	{
		// 이전에 저장된 상태가 있으면 불러오기
		LoadState();

		// 모든 버튼들에 클릭 이벤트 추가
		for (int i = 0; i < buttons.Length; i++)
		{
			int index = i; // 지역 변수를 사용하여 클로저 문제 해결
			buttons[i].onClick.AddListener(() => OnButtonClick(index));

			// 이전 상태를 반영하여 버튼 활성화/비활성화 설정
			if (index == selectedButtonIndex)
			{
				SetButtonState(buttons[i], false); // 비활성화
			}
		}
	}

	// 버튼이 클릭되었을 때 호출되는 메서드
	private void OnButtonClick(int buttonIndex)
	{
		// 이미 선택된 버튼은 무시
		if (buttonIndex == selectedButtonIndex)
			return;

		// 새로운 버튼이 선택되었을 때
		selectedButtonIndex = buttonIndex;

		// 배경 스프라이트 변경
		if (buttonIndex >= 0 && buttonIndex < sprites.Length)
		{
			background.sprite = sprites[buttonIndex];
		}

		// 모든 버튼을 활성화하고 현재 버튼은 비활성화
		for (int i = 0; i < buttons.Length; i++)
		{
			if (i == selectedButtonIndex)
			{
				SetButtonState(buttons[i], false); // 비활성화
			}
			else
			{
				SetButtonState(buttons[i], true); // 활성화
			}
		}

		// 상태 저장
		SaveState();
	}

	// 버튼의 활성화/비활성화 상태를 설정하는 메서드
	private void SetButtonState(Button button, bool isActive)
	{
		button.interactable = isActive;

		Image buttonImage = button.GetComponent<Image>();
		if (buttonImage != null)
		{
			buttonImage.color = isActive ? Color.white : Color.gray; // 활성화: 흰색, 비활성화: 회색
		}
	}

	// 상태를 저장하는 메서드
	private void SaveState()
	{
		PlayerPrefs.SetInt(gameObject.name + "_SelectedButtonIndex", selectedButtonIndex);
		PlayerPrefs.SetString(gameObject.name + "_BackgroundSprite", background.sprite.name);
		PlayerPrefs.Save();
	}

	// 상태를 불러오는 메서드
	private void LoadState()
	{
		selectedButtonIndex = PlayerPrefs.GetInt(gameObject.name + "_SelectedButtonIndex", -1);

		string backgroundSpriteName = PlayerPrefs.GetString(gameObject.name + "_BackgroundSprite", "");
		if (!string.IsNullOrEmpty(backgroundSpriteName))
		{
			Sprite savedSprite = Resources.Load<Sprite>(backgroundSpriteName);
			if (savedSprite != null)
			{
				background.sprite = savedSprite;
			}
		}
	}
}