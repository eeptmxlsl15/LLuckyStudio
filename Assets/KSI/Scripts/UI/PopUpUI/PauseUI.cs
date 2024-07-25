using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class PauseUI : MonoBehaviour
{
	public string gameModeSceneToLoad;

	[SerializeField] private GameObject pauseUI;
	[SerializeField] private Button resumeButton;
	[SerializeField] private Button quitButton;

	private bool isPaused = false;

	private void Start()
	{
		pauseUI.SetActive(false);
		resumeButton.onClick.AddListener(ResumeGame);
		quitButton.onClick.AddListener(QuitGame);
	}

	public void PauseGame()
	{
		pauseUI.SetActive(true);
		Time.timeScale = 0f;
		isPaused = true;
	}

	public void ResumeGame()
	{
		pauseUI.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false;
	}

	public void QuitGame()
	{
		Time.timeScale = 1f;
		UnitySceneManager.LoadScene(gameModeSceneToLoad);
	}
}
