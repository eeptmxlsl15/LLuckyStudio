using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
	[SerializeField] private float speed = 1f;

	public abstract void Contact();

	private void Start()
	{
		
	}

	private void Update()
	{
		Move();
	}

	private void Move()
	{
		transform.Translate(Vector3.left * speed * Time.deltaTime);

		if (transform.position.x < -10f)
		{
			Destroy(gameObject);
		}
	}
}
