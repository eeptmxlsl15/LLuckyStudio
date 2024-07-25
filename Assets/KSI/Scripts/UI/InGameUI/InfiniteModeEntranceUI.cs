using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class InfiniteModeEntranceUI : MonoBehaviour
{
	public string gameModeSceneToLoad;

	private bool isCloseButtonPressed = false;

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
			UnitySceneManager.LoadScene(gameModeSceneToLoad);
		}
	}

	public void CloseButton()
	{
		isCloseButtonPressed = true;
	}
}
