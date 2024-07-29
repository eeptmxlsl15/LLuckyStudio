using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class InfiniteModeEntranceUI : MonoBehaviour
{
	[SerializeField] private GameObject infiniteModeEntranceUI;

	private bool isCloseButtonPressed = false;

	private void Start()
	{
		infiniteModeEntranceUI.SetActive(false);
	}

	public void LoadGameModeScene()
	{
		isCloseButtonPressed = false;

		StartCoroutine(LoadGameModeSceneDelayRoutine(3.0f));
	}

	private IEnumerator LoadGameModeSceneDelayRoutine(float delay)
	{
		yield return new WaitForSeconds(delay);

		if (!isCloseButtonPressed)
		{
			UnitySceneManager.LoadScene("INFINITEScene");
		}
	}

	public void CloseButton()
	{
		isCloseButtonPressed = true;
		infiniteModeEntranceUI.SetActive(false);
	}
}
