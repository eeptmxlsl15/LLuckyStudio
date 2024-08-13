using UnityEngine;
using BackEnd;
using UnityEngine.Events;

public class BackendGameData
{
	[System.Serializable]
	public class GameDataLoadEvent : UnityEvent { }
	public GameDataLoadEvent onGameDataLoadEvent = new GameDataLoadEvent();

	private static BackendGameData instance = null;
	public static BackendGameData Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new BackendGameData();
			}

			return instance;
		}
	}

	private UserGameData userGameData = new UserGameData();
	public UserGameData UserGameData => userGameData;

	private string gameDataRowInDate = string.Empty;

	public void GameDataInsert()
	{
		userGameData.Reset();

		Param param = new Param()
		{
			{"INFINITBestscore", userGameData.INFINITBestscore},
			{"sushi", userGameData.sushi},
			{"cannedFood", userGameData.cannedFood},
			{"silverKey", userGameData.silverKey},
			{"goldKey", userGameData.goldKey},
			{"money", userGameData.money},
			{"brokenBlue", userGameData.brokenBlue},
			{"brokenRed", userGameData.brokenRed},
			{"brokenGreen", userGameData.brokenGreen},

			{"resurrection", userGameData.resurrection},
			{"wizardBackground", userGameData.wizardHuntBackground},
			{"wizardHuntEffect", userGameData.wizardHuntEffect},
			{"wizardHuntSkin", userGameData.brokenGreen},
			{"nabinyangBackground", userGameData.nabinyangBackground},
			{"nabinyangEffect;", userGameData.nabinyangEffect},
			{"nabinyangSkin;", userGameData.nabinyangSkin}
	};

		Backend.GameData.Insert("USER_DATA", param, callback =>
		{
			if (callback.IsSuccess())
			{
				gameDataRowInDate = callback.GetInDate();

				Debug.Log($"게임 정보 데이터 삽입에 성공했습니다. : {callback}");
			}
			else
			{
				Debug.LogError($"게임 정보 데이터 삽입에 실패했습니다. : {callback}");
			}
		});
	}

	public void GameDataLoad()
	{
		Backend.GameData.GetMyData("USER_DATA", new Where(), callback =>
		{
			if (callback.IsSuccess())
			{
				Debug.Log($"게임 정보 데이터 불러오기에 성공했습니다. : {callback}");

				try
				{
					LitJson.JsonData gameDataJson = callback.FlattenRows();

					if (gameDataJson.Count <= 0)
					{
						Debug.LogWarning("데이터가 존재하지 않습니다.");
					}
					else
					{
						gameDataRowInDate = gameDataJson[0]["inDate"].ToString();

						userGameData.INFINITBestscore = int.Parse(gameDataJson[0]["INFINITBestscore"].ToString());						
						userGameData.cannedFood = int.Parse(gameDataJson[0]["cannedFood"].ToString());
						userGameData.silverKey = int.Parse(gameDataJson[0]["silverKey"].ToString());
						userGameData.goldKey = int.Parse(gameDataJson[0]["goldKey"].ToString());
						userGameData.money = int.Parse(gameDataJson[0]["money"].ToString());
						userGameData.brokenBlue = int.Parse(gameDataJson[0]["brokenBlue"].ToString());
						userGameData.brokenRed = int.Parse(gameDataJson[0]["brokenRed"].ToString());
						userGameData.brokenGreen = int.Parse(gameDataJson[0]["brokenGreen"].ToString());
						userGameData.sushi = int.Parse(gameDataJson[0]["sushi"].ToString());
						
						userGameData.resurrection = int.Parse(gameDataJson[0]["resurrection"].ToString());
						userGameData.wizardHuntBackground = int.Parse(gameDataJson[0]["wizardHuntBackground"].ToString());
						userGameData.wizardHuntEffect = int.Parse(gameDataJson[0]["wizardHuntEffect"].ToString());
						userGameData.wizardHuntSkin = int.Parse(gameDataJson[0]["wizardHuntSkin"].ToString());
						userGameData.nabinyangBackground = int.Parse(gameDataJson[0]["nabinyangBackground"].ToString());
						userGameData.nabinyangEffect = int.Parse(gameDataJson[0]["nabinyangEffect"].ToString());
						userGameData.nabinyangSkin = int.Parse(gameDataJson[0]["nabinyangSkin"].ToString());

						// 각 데이터를 디버그 로그로 출력
						Debug.Log($"INFINITBestscore: {userGameData.INFINITBestscore}");
						Debug.Log($"Canned Food: {userGameData.cannedFood}");
						Debug.Log($"Silver Key: {userGameData.silverKey}");
						Debug.Log($"Gold Key: {userGameData.goldKey}");
						Debug.Log($"Money: {userGameData.money}");
						Debug.Log($"Broken Blue: {userGameData.brokenBlue}");
						Debug.Log($"Broken Red: {userGameData.brokenRed}");
						Debug.Log($"Broken Green: {userGameData.brokenGreen}");
						Debug.Log($"Sushi: {userGameData.sushi}");

						Debug.Log($"Resurrection: {userGameData.resurrection}");
						Debug.Log($"WizardHuntBackground: {userGameData.wizardHuntBackground}");
						Debug.Log($"WizardHuntEffect: {userGameData.wizardHuntEffect}");
						Debug.Log($"WizardHuntSkin: {userGameData.wizardHuntSkin}");
						Debug.Log($"NabinyangBackground: {userGameData.nabinyangBackground}");
						Debug.Log($"NabinyangEffect: {userGameData.nabinyangEffect}");
						Debug.Log($"NabinyangSkin;: {userGameData.nabinyangSkin}");




						onGameDataLoadEvent?.Invoke();
					}
				}
				catch (System.Exception e)
				{
					userGameData.Reset();
					Debug.LogError(e);
				}
			}
			else
			{
				Debug.LogError($"게임 정보 데이터 불러오기에 실패했습니다. : {callback}");
			}
		});
	}

	public void GameDataUpdate(UnityAction action = null)
	{
		if (userGameData == null)
		{
			Debug.LogError("서버에서 다운받거나 새로 삽입한 데이터가 존재하지 않습니다." +
						   "Insert 혹은 Load를 통해 데이터를 생성해주세요.");
			return;
		}

		Param param = new Param()
		{
			{"INFINITBestscore", userGameData.INFINITBestscore},
			{"sushi", userGameData.sushi},
			{"cannedFood", userGameData.cannedFood},
			{"silverKey", userGameData.silverKey},
			{"goldKey", userGameData.goldKey},
			{"money", userGameData.money},
			{"brokenBlue", userGameData.brokenBlue},
			{"brokenRed", userGameData.brokenRed},
			{"brokenGreen", userGameData.brokenGreen},

			{"resurrection", userGameData.resurrection},
			{"wizardBackground", userGameData.wizardHuntBackground},
			{"wizardHuntEffect", userGameData.wizardHuntEffect},
			{"wizardHuntSkin", userGameData.brokenGreen},
			{"nabinyangBackground", userGameData.nabinyangBackground},
			{"nabinyangEffect;", userGameData.nabinyangEffect},
			{"nabinyangSkin;", userGameData.nabinyangSkin}
		};

		if (string.IsNullOrEmpty(gameDataRowInDate))
		{
			Debug.LogError($"유저의 inDate 정보가 없어 게임 정보 데이터 수정에 실패했습니다.");
		}
		else
		{
			Debug.Log($"{gameDataRowInDate}의 게임 정보 데이터 수정을 요청합니다.");

			Backend.GameData.UpdateV2("USER_DATA", gameDataRowInDate, Backend.UserInDate, param, callback =>
			{
				if (callback.IsSuccess())
				{
					Debug.Log($"게임 정보 데이터 수정에 성공했습니다. : {callback}");

					action?.Invoke();

					onGameDataLoadEvent?.Invoke();
				}
				else
				{
					Debug.LogError($"게임 정보 데이터 수정에 실패했습니다. : {callback}");
				}
			});
		}
	}
}

