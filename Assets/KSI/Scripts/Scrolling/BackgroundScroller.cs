using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
	[SerializeField] public float speed;
	
	private MeshRenderer render;
	private float x = 0;
	private float y = 0;

	private void Awake()
	{
		render = GetComponent<MeshRenderer>();
	}

	private void Update()
	{
		render.material.mainTextureOffset = new Vector2(x, y);
		x = x + Time.deltaTime * speed;
	}
}


