using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Transform player;

	private Vector3 offset;

	void Start()
	{
		offset = transform.position - player.position; 
	}

	void LateUpdate()
	{
		Vector3 newPosition = player.position + offset;
		transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z);
	}
}
