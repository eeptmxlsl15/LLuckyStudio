using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractAdapter : MonoBehaviour, IInteractable
{
	public UnityEvent<Interactor> OnInteracted;

	public void Interact(Interactor interactor)
	{
		OnInteracted?.Invoke(interactor);
	}
}
