using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Runtime.Serialization;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class GameManager : MonoBehaviour
{
	static GameManager instance;
	static ResourceManager resourceManager;
	static PoolManager poolManager;
	static UIManager uiManager;
	static SceneManager sceneManager;
	static ScoreManager scoreManager;
	static BerserkSystemManager berserkSystemManager;
	static GameModeSystem gameModeSystem;

	public static GameManager Instance { get { return instance; } }
	public static ResourceManager Resource { get { return resourceManager; } }
	public static PoolManager Pool { get { return poolManager; } }
	public static UIManager UI { get { return uiManager; } }
	public static SceneManager Scene { get { return sceneManager; } }
	public static ScoreManager Score { get { return scoreManager; } }
	public static BerserkSystemManager BerserkSystem { get { return berserkSystemManager; } }
	
	public BerserkSystemManager.ZodiacSign BossDebuff { get; set; }
	public BerserkSystemManager.ZodiacSign InfiniteDebuff1 { get; set; }
	public BerserkSystemManager.ZodiacSign InfiniteDebuff2 { get; set; }


	private void Awake()
	{
		if (instance != null)
		{
			Destroy(this);
			return;
		}

		instance = this;
		DontDestroyOnLoad(this);

		InitManagers();
	}

	private void OnDestroy()
	{
		if (instance == this)
			instance = null;
	}

	private void InitManagers()
	{
		GameObject resourceObject = new GameObject();
		resourceObject.name = "ResourceManager";
		resourceObject.transform.parent = transform;
		resourceManager = resourceObject.AddComponent<ResourceManager>();

		GameObject poolObject = new GameObject();
		poolObject.name = "PoolManager";
		poolObject.transform.parent = transform;
		poolManager = poolObject.AddComponent<PoolManager>();

		GameObject uiObject = new GameObject();
		uiObject.name = "UIManager";
		uiObject.transform.parent = transform;
		uiManager = uiObject.AddComponent<UIManager>();

		GameObject sceneObject = new GameObject();
		sceneObject.name = "SceneManager";
		sceneObject.transform.parent = transform;
		sceneManager = sceneObject.AddComponent<SceneManager>();

		GameObject scoreObject = new GameObject();
		scoreObject.name = "ScoreManager";
		scoreObject.transform.parent = transform;
		scoreManager = scoreObject.AddComponent<ScoreManager>();

		GameObject berserkSystemObject = new GameObject();
		berserkSystemObject.name = "BerserkSystemManager";
		berserkSystemObject.transform.parent = transform;
		berserkSystemManager = berserkSystemObject.AddComponent<BerserkSystemManager>();

		GameObject gameModeSystemObject = new GameObject();
		gameModeSystemObject.name = "GameModeSystem ";
		gameModeSystemObject.transform.parent = transform;
		gameModeSystem = gameModeSystemObject.AddComponent<GameModeSystem>();
	}

	public void ResetBossDebuff()
	{
		BossDebuff = default(BerserkSystemManager.ZodiacSign);
	}

	public void ResetInfiniteDebuff()
	{
		InfiniteDebuff1 = default(BerserkSystemManager.ZodiacSign);
		InfiniteDebuff2 = default(BerserkSystemManager.ZodiacSign);
	}
}