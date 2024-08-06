using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using System.Threading.Tasks;
using BackEnd.MultiCharacter;

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

		yield return StartCoroutine(CustomLoginAsyncRoutine("kangsooin", "1234"));
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

	public void CustomLogin(string id, string pw)
	{
		StartCoroutine(CustomLoginAsyncRoutine(id, pw));
	}

	IEnumerator CustomLoginAsyncRoutine(string id, string pw)
	{
		// Task.Run을 사용하여 백그라운드 스레드에서 실행될 비동기 작업 시작
		yield return new WaitTask(Task.Run(() =>
		{
			Debug.Log("로그인 요청합니다.");

			// 뒤끝 서버 SDK를 이용한 사용자 정의 로그인 요청
			var bro = Backend.BMember.CustomLogin(id, pw);

			// 로그인 요청 결과에 따른 처리
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
}


