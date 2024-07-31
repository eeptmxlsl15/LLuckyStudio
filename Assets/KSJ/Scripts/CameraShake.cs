using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public float shakeForce = 0f;
	public Vector3 offset = Vector3.zero;
	public float shakeDuration = 0.1f; // 카메라 흔들림 지속 시간

	Quaternion originRotation;

	void Start()
	{
		originRotation = transform.rotation;
	}

	public void ShakeStart()
	{
		StartCoroutine(ShakeCoroutine());
	}

	IEnumerator ShakeCoroutine()
	{
		Vector3 originEuler = transform.eulerAngles;
		float tiem = 0f;

		while (tiem < shakeDuration)
		{
			float rotX = Random.Range(-offset.x, offset.x);
			float rotY = Random.Range(-offset.y, offset.y);
			float rotZ = Random.Range(-offset.z, offset.z);

			Vector3 randomRotation = originEuler + new Vector3(rotX, rotY, rotZ);
			Quaternion rot = Quaternion.Euler(randomRotation);

			while (Quaternion.Angle(transform.rotation, rot) > 0.1f)
			{
				transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, shakeForce * Time.deltaTime);
				yield return null;
			}

			tiem += Time.deltaTime;
			yield return null;
		}

		// 흔들림이 끝난 후 원래 회전으로 복원
		while (Quaternion.Angle(transform.rotation, originRotation) > 0f)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, originRotation, shakeForce * Time.deltaTime);
			yield return null;
		}
	}
}