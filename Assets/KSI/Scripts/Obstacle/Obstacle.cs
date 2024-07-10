using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour, IDamagable
{
	public int damage = 10;

	public void TakeDamage(int damage) { }

	private void OnTriggerEnter2D(Collider2D other)
	{
		IDamagable damagable = other.GetComponent<IDamagable>();
		if (damagable != null)
		{
			damagable.TakeDamage(damage);
		}
	}
}
