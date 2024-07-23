using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class InfiniteModeEntranceUI : MonoBehaviour
{
	public string gameModeSceneToLoad;

	public void LoadGameModeScene()
	{
		StartCoroutine(LoadGameModeSceneDelayRoutine(3.0f));
	}

	private IEnumerator LoadGameModeSceneDelayRoutine(float delay)
	{
		yield return new WaitForSeconds(delay);
		UnitySceneManager.LoadScene(gameModeSceneToLoad);
	}
}
