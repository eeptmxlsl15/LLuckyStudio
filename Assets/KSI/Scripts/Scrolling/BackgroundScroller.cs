using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private float scrollAmount;
	[SerializeField] private float moveSpeed;
	[SerializeField] private Vector3 moveDirection;

	private void Update()
	{
		transform.position += moveDirection * moveSpeed * Time.deltaTime;

		// 배경이 설정된 범위를 벗어나면 위치 재설정함
		if (transform.position.x <= -scrollAmount)
		{
			transform.position = target.position - moveDirection * scrollAmount;
		}
	}
}

