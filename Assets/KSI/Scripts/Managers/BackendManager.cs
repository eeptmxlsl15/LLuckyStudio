using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using System.Threading.Tasks;
using BackEnd.MultiCharacter;

public class BackendManager : MonoBehaviour
{
	private void Awake()
	{
		BackendSetup();
	}

	private void Update()
	{
		// 서버의 비동기 메소드 호출(콜백 함수 풀링)을 위해 작성
		if (Backend.IsInitialized)
		{
			Backend.AsyncPoll();
		}
	}

	private void BackendSetup()
	{
		// 뒤끝 초기화 (콜백 함수 풀링을 사용하려면 매개변수를 true로 설정)
		var bro = Backend.Initialize(true);

		// 뒤끝 초기화에 대한 응답값
		if (bro.IsSuccess())
		{
			// 초기화 성공 시 statusCode 204 Success
			Debug.Log($"초기화 성공 : {bro}");
		}
		else
		{
			// 초기화 실패 시 statusCode 400대 에러 발생
			Debug.LogError($"초기화 실패 : {bro}");
		}
	}

	private IEnumerator TestRoutine()
	{
		//yield return StartCoroutine(CustomSignUpAsyncRoutine("kangsooin", "1234"));

		yield return StartCoroutine(CustomLoginAsyncRoutine("kangsooin", "1234"));
	}

	public void CustomSignUp(string id, string pw)
	{
		StartCoroutine(CustomSignUpAsyncRoutine(id, pw));
	}

	private IEnumerator CustomSignUpAsyncRoutine(string id, string pw)
	{
		yield return new WaitTask(Task.Run(() =>
		{
			Debug.Log("회원가입 요청합니다.");

			var bro = Backend.BMember.CustomSignUp(id, pw);

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

	public void CustomLogin(string id, string pw)
	{
		StartCoroutine(CustomLoginAsyncRoutine(id, pw));
	}

	private IEnumerator CustomLoginAsyncRoutine(string id, string pw)
	{
		yield return new WaitTask(Task.Run(() =>
		{
			Debug.Log("로그인 요청합니다.");

			var bro = Backend.BMember.CustomLogin(id, pw);

			if (bro.IsSuccess())
			{
				Debug.Log("로그인 성공했습니다. : " + bro);
			}
			else
			{
				Debug.LogError("로그인 실패했습니다. : " + bro);
			}
		}));
	}

	public void CustomLogOut()
	{
		var bro = Backend.BMember.Logout();
		if (bro.IsSuccess())
		{
			Debug.Log("게스트 회원 탈퇴 성공 : " + bro);
		}
		else
		{
			Debug.Log("게스트 회원 탈퇴 실패 : " + bro);
		}
	}

	public void CustomWithdraw()
	{
		var bro = Backend.BMember.WithdrawAccount();

		if (bro.IsSuccess())
		{
			Debug.Log("게스트 회원 탈퇴 성공 : " + bro);
		}
		else
		{
			Debug.Log("게스트 회원 탈퇴 실패 : " + bro);
		}
	}
}


