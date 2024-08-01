using UnityEngine;

public class BOSSSceneHorse : MonoBehaviour
{
	private DebuffSystem debuffSystem;

	private void Start()
    {
		debuffSystem = FindObjectOfType<DebuffSystem>();

		debuffSystem.OnHorseDebuffChanged.Invoke();
		Debug.Log("OnHorseDebuffChanged.");
	}
}
