using UnityEngine;

public class BOSSSceneDragon : MonoBehaviour
{
	private DebuffSystem debuffSystem;

	private void Start()
    {
		debuffSystem = FindObjectOfType<DebuffSystem>();

		debuffSystem.OnDragonDebuffChanged.Invoke();
		Debug.Log("OnDragonDebuffChanged.");
	}
}
