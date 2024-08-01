using UnityEngine;

public class BERSERKBOSSSceneHorse : MonoBehaviour
{
	private DebuffSystem debuffSystem;

	private void Start()
    {
		debuffSystem = FindObjectOfType<DebuffSystem>();

		debuffSystem.OnHorseDebuffChanged.Invoke();
		Debug.Log("OnHorseDebuffChanged.");
	}
}
