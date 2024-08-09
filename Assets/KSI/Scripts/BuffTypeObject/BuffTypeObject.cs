using UnityEngine;
using System.Collections;

// 버프형 오브젝트
// 파괴됨
public abstract class BuffTypeObject : MonoBehaviour
{
	[SerializeField] protected float speed = 10f;
	protected AudioClip getSound;
	protected Player player;

	public abstract void Buff();

	private void Update()
	{
		Move();
	}

	protected virtual void Move()
	{
		transform.Translate(Vector3.left * speed * Time.deltaTime);

		Destroy(gameObject, 20f);
	}
}
