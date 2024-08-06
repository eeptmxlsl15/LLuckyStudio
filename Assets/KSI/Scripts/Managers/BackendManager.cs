using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using System.Threading.Tasks;

public class BackendManager : MonoBehaviour
{
	private void Start()
	{
		var bro = Backend.Initialize(true);

		if (bro.IsSuccess())
		{
			Debug.Log("초기화 성공 : " + bro);
		}
		else
		{
			Debug.LogError("초기화 실패 : " + bro);
		}

		StartCoroutine(TestRoutine());
	}

	private IEnumerator TestRoutine()
	{
		yield return StartCoroutine(CustomSignUpAsyncRoutine("kangsooin", "1234"));
	}

	public void CustomSignUp(string id, string pw)
	{
		StartCoroutine(CustomSignUpAsyncRoutine(id, pw));
	}

	// 비동기 방식으로 회원가입 요청 처리
	IEnumerator CustomSignUpAsyncRoutine(string id, string pw)
	{
		// Task.Run을 사용하여 백그라운드 스레드에서 실행될 비동기 작업 시작
		yield return new WaitTask(Task.Run(() =>
		{
			Debug.Log("회원가입 요청합니다.");

			// 뒤끝 서버 SDK를 이용한 사용자 정의 회원가입 요청
			var bro = Backend.BMember.CustomSignUp(id, pw);

			// 회원가입 요청 결과에 따른 처리
			if (bro.IsSuccess())
			{
				Debug.Log("회원가입 성공했습니다. : " + bro);
			}
			else
			{
				Debug.LogError("회원가입 실패했습니다. : " + bro);
			}
		}));
	}

	//async void Test()
	//{
	//	await Task.Run(() => {
	//		CustomLogin("강수인", "1234");
	//		// UpdateNickname("LLucky Studio");
	//		BackendGameData.Instance.GameDataInsert();
	//		// TODO : 데이터 삽입 함수
	//		Debug.Log("테스트를 종료합니다.");
	//	});
	//}



	//public void CustomSignUp(string id, string pw)
	//{
	//	Debug.Log("회원가입을 요청합니다.");

	//	var bro = Backend.BMember.CustomSignUp(id, pw);

	//	if (bro.IsSuccess())
	//	{
	//		Debug.Log("회원가입에 성공했습니다. : " + bro);
	//	}
	//	else
	//	{
	//		Debug.LogError("회원가입에 실패했습니다. : " + bro);
	//	}
	//}

	//public void CustomLogin(string id, string pw)
	//{
	//	Debug.Log("로그인을 요청합니다.");

	//	var bro = Backend.BMember.CustomLogin(id, pw);

	//	if (bro.IsSuccess())
	//	{
	//		Debug.Log("로그인이 성공했습니다. : " + bro);
	//	}
	//	else
	//	{
	//		Debug.LogError("로그인이 실패했습니다. : " + bro);
	//	}
	//}

	//public void UpdateNickname(string nickname)
	//{
	//	Debug.Log("닉네임 변경을 요청합니다.");

	//	var bro = Backend.BMember.UpdateNickname(nickname);

	//	if (bro.IsSuccess())
	//	{
	//		Debug.Log("닉네임 변경에 성공했습니다 : " + bro);
	//	}
	//	else
	//	{
	//		Debug.LogError("닉네임 변경에 실패했습니다 : " + bro);
	//	}
	//}
}


