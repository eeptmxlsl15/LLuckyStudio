using UnityEngine;

public class BERSERKBOSSSceneRabbit : MonoBehaviour
{
	private DebuffSystem debuffSystem;

	private void Start()
    {
		debuffSystem = FindObjectOfType<DebuffSystem>();

		debuffSystem.OnRabbitDebuffChanged.Invoke();
		Debug.Log("OnRabbitDebuffChanged.");
	}
}
