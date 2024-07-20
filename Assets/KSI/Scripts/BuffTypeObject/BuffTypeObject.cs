using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 버프형 오브젝트
// 파괴됨
public abstract class BuffTypeObject : MonoBehaviour
{
	public float speed = 10f;

	protected Player player;

	public abstract void Buff();

	private void Update()
	{
		Move();
	}

	protected virtual void Move()
	{
		transform.Translate(Vector3.left * speed * Time.deltaTime);

		Destroy(gameObject, 5f);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		player = other.GetComponent<Player>();
		if (player != null)
		{
			Buff();
			Destroy(gameObject);
			Debug.Log("버프");
		}
	}
}
