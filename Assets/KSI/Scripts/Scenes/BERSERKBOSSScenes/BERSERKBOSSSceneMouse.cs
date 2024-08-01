using UnityEngine;

public class BERSERKBOSSSceneMouse : MonoBehaviour
{
	private DebuffSystem debuffSystem;

	private void Start()
    {
		debuffSystem = FindObjectOfType<DebuffSystem>();

		debuffSystem.OnMouseDebuffChanged.Invoke();
		Debug.Log("OnMouseDebuffChanged.");
	}
}
