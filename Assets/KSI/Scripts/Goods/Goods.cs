using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Goods : MonoBehaviour
{
	[SerializeField] private float speed = 10f;
	[SerializeField] protected int scoreValue = 100;
	protected IScore scoreAdapter;

	public abstract void Contact();

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