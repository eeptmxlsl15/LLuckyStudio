using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 버프형 오브젝트
// 파괴됨
public abstract class BuffTypeObject : MonoBehaviour
{
	protected KSIPlayerController player;

	public abstract void Buff();

	private void OnTriggerEnter2D(Collider2D other)
	{
		player = other.GetComponent<KSIPlayerController>();
		if (player != null)
		{
			Buff();
			Destroy(gameObject);
		}
	}
}
