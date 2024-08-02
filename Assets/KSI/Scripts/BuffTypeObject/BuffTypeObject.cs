using UnityEngine;
using System.Collections;

// 버프형 오브젝트
// 파괴됨
public abstract class BuffTypeObject : MonoBehaviour
{
	protected float speed = 10f;
	protected Player player;

	public abstract void Buff();

	private void Update()
	{
		if (GameManager.Instance != null && GameManager.Instance.IsGameStarted)
		{
			Move();
		}
	}

	protected virtual void Move()
	{
		transform.Translate(Vector3.left * speed * Time.deltaTime);

		//Destroy(gameObject, 5f);
	}
}
