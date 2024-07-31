using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public float shakeForce = 0f;
	public Vector3 offset = Vector3.zero;

	Quaternion originRotation;


	
    // Start is called before the first frame update
    void Start()
    {
		originRotation = transform.rotation;


	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
			ShakeStart();
		if (Input.GetKeyDown(KeyCode.A))
			ShakeEnd();

	}

	public void ShakeStart()
	{
		StartCoroutine(ShakeCoroutine());
	}
	public void ShakeEnd()
	{
		StopCoroutine(ShakeCoroutine());
		StartCoroutine(Reset());

	}
	IEnumerator ShakeCoroutine() {
		Vector3 originEuler = transform.eulerAngles;
		while (true)
		{
			float rotX = Random.Range(offset.x, offset.x);
			float rotY = Random.Range(offset.y, offset.y);
			float rotZ = Random.Range(offset.z, offset.z);

			Vector3 randomRotation = originEuler + new Vector3(rotX, rotY, rotZ);
			Quaternion rot = Quaternion.Euler(randomRotation);

			while (Quaternion.Angle(transform.rotation, rot) > 0.1f)
			{
				transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, shakeForce * Time.deltaTime);
				yield return null;

			}
			yield return null;
		}
	}

	IEnumerator Reset()
	{
		while(Quaternion.Angle(transform.rotation , originRotation) > 0f)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, originRotation, shakeForce + Time.deltaTime);
			yield return null;
		}
	}
}
