using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;


public class StoryModeSelectUI : MonoBehaviour
{
	public string gameModeSceneToLoad;

	public void LoadGameModeScene()
	{
		UnitySceneManager.LoadScene(gameModeSceneToLoad);
	}
}
