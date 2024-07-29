using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : MonoBehaviour
{
	[Header("UI")]
	[SerializeField] private GameObject storyModeEntranceUI;
	[SerializeField] private GameObject InfiniteModeEntranceUI;

	private void Start()
    {
		storyModeEntranceUI.SetActive(false);
		InfiniteModeEntranceUI.SetActive(false);
	}
}
