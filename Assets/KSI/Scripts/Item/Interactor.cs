using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
	public int scoreValue = 10;

	private void Interact()
	{
		ScoreManager.instance.AddScore(scoreValue);
		Destroy(gameObject);
	}

	private void OnInteract()
	{
		Interact();
	}

	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Interact();
		}
	}

}
