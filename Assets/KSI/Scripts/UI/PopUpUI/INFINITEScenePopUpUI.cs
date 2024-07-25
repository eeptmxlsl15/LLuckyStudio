using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class INFINITEScenePopUpUI : MonoBehaviour
{
	[SerializeField] private GameObject popupPanel;

	private void Start()
	{
		ShowPopup();
	}

	public void ShowPopup()
	{
		popupPanel.SetActive(true);
		Time.timeScale = 0f;
	}

	public void ClosePopup()
	{
		popupPanel.SetActive(false); 
		Time.timeScale = 1f;
	}

	private void GameStart()
	{
		GameManager.Scene.StartGame();
	}
}
