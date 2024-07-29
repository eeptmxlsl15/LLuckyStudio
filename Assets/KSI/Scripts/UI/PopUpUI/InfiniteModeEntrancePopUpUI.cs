using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

/* 삭제 */
//public class InfiniteModeEntrancePopUpUI : PopUpUI
//{
//	private bool isCloseButtonPressed = false;

//	protected override void Awake()
//	{
//		base.Awake();

//		buttons["InfiniteModeEntranceBackButton"].onClick.AddListener(() =>
//		{
//			isCloseButtonPressed = true;
//			GameManager.UI.ClosePopUpUI(); 
//		});		
//	}

//	private void OnEnable()
//	{
//		StartCoroutine(LoadGameModeSceneDelayRoutine(3.0f));
//	}

//	private void LoadGameModeScene()
//	{
//		isCloseButtonPressed = false;

//		StartCoroutine(LoadGameModeSceneDelayRoutine(3.0f));
//	}

//	private IEnumerator LoadGameModeSceneDelayRoutine(float delay)
//	{
//		yield return new WaitForSeconds(delay);

//		if (!isCloseButtonPressed)
//		{
//			UnitySceneManager.LoadScene("INFINITEScene");
//		}
//	}
//}
