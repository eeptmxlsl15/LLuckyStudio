using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
	//[SerializeField] private Transform target;
	//[SerializeField] private float scrollAmount;
	//[SerializeField] private float moveSpeed;
	//[SerializeField] private Vector3 moveDirection;

	//private void Update()
	//{
	//	transform.position += moveDirection * moveSpeed * Time.deltaTime;

	//	// 배경이 설정된 범위를 벗어나면 위치 재설정함
	//	if (transform.position.x <= -scrollAmount)
	//	{
	//		transform.position = target.position - moveDirection * scrollAmount;
	//	}
	//}


	private Transform cam;
	private Vector3 camStartPos;
	private float distance;

	GameObject[] background;
	Material[] mat;
	float[] backSpeed;

	float farthestBack;

	[Range(0.01f, 0.05f)]
	public float parallaxSpeed;

	private void Start()
	{
		cam = Camera.main.transform;
		camStartPos = cam.position;

		int backCount = transform.childCount;
		mat = new Material[backCount];
		backSpeed = new float[backCount];
		background = new GameObject[backCount];

		for (int i = 0; i < backCount; i++)
		{
			background[i] = transform.GetChild(i).gameObject;
			mat[i] = background[i].GetComponent<Renderer>().material;
		}

		BackSpeedCalulate(backCount);
	}

	private void BackSpeedCalulate(int backCount)
	{
		for (int i = 0; i < backCount; i++)
		{
			if ((background[i].transform.position.z - cam.position.z) > farthestBack)
			{
				farthestBack = background[i].transform.position.z - cam.position.z;
			}
		}

		for (int i = 0; i < backCount; i++)
		{
			backSpeed[i] = 1 - (background[i].transform.position.z - cam.position.z) / farthestBack;
		}
	}

	private void LateUpdate()
	{
		distance = cam.position.x - camStartPos.x;

		for (int i = 0; i < background.Length; i++)
		{
			float speed = backSpeed[i] * parallaxSpeed;
			mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
		}
	}
}

