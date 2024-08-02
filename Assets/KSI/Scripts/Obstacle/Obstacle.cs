using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 장애물
// 파괴 안됨
public abstract class Obstacle : MonoBehaviour, IDamagable
{
	[SerializeField] private float speed = 10f;
	[SerializeField] protected int damage = 10;

	public void TakeDamage(int damage) { }

	private void Update()
	{
		//if (GameManager.Instance != null && GameManager.Instance.IsGameStarted)
		//{
			Move();
		//}
	}

	protected virtual void Move()
	{
		transform.Translate(Vector3.left * speed * Time.deltaTime);

		//Destroy(gameObject, 10f);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		IDamagable damagable = other.GetComponent<IDamagable>();
		if (damagable != null)
		{
			damagable.TakeDamage(damage);
		}
	}
}
