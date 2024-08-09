using UnityEngine;

public abstract class Goods : MonoBehaviour
{
	[SerializeField] private float speed = 10f;
	protected int scoreValue = 100;
	protected IScore scoreAdapter;
	protected AudioClip getSound;

	public abstract void Contact();

	private void Update()
	{
		Move();
	}

	protected virtual void Move()
	{
		transform.Translate(Vector3.left * speed * Time.deltaTime);

		//Destroy(gameObject, 20f);
	}
}