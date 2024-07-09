using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
	[SerializeField] private int scoreValue = 10;

	private void Interact()
	{
		GameManager.Score.AddScore(scoreValue);
		Destroy(gameObject);
	}

	private void OnInteract()
	{
		Interact();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{		
		IInteractable interactable = other.GetComponent<IInteractable>();

		if (interactable != null)
		{
			interactable.Interact(this);
		}
	}
}
