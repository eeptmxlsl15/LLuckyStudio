using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 움직이는 발판
// 위아래로 움직임
public class MovingPlatform : Platform
{
	[SerializeField] private float speed = 3.0f; // 속도
	[SerializeField] private float maxHeight = 1.0f; // 최대 높이
	[SerializeField] private float minHeight = -1.0f; // 최소 높이

	private Vector3 initialPosition; // 초기 위치

	private void Start()
	{
		// 초기 위치 저장
		initialPosition = transform.position;
	}

	void Update()
	{
		Move();
	}

	public override void Pass()
	{
		// TODO : 통과
	}

	private void Move()
	{
		// PingPong 함수로 위아래로 움직임
		float y = Mathf.PingPong(Time.time * speed, maxHeight - minHeight) + minHeight;
		// Y 위치 업데이트
		transform.position = new Vector3(initialPosition.x, initialPosition.y + y, initialPosition.z);
	} 
}
