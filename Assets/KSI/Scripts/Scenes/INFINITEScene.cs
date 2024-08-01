using UnityEngine;

public class INFINITEScene : MonoBehaviour
{
	public GameObject popupPanel;

	private void Awake()
	{
		Time.timeScale = 0f;
	}

	public void StartButton()
	{
		popupPanel.SetActive(false);

		Time.timeScale = 1f;

		GameManager.Instance.StartGame();
	}
}
