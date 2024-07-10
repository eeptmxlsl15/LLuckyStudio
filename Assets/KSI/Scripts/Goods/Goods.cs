using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Goods : MonoBehaviour
{
	[SerializeField] private float speed = 10f;
	[SerializeField] protected int scoreValue = 10;
	protected IScore scoreAdapter;

	public abstract void Contact();

	private void Update()
	{
		Move();
	}

	protected virtual void Move()
	{
		transform.Translate(Vector3.left * speed * Time.deltaTime);

		if (transform.position.x < -10f)
		{
			Destroy(gameObject);
		}
	}
}