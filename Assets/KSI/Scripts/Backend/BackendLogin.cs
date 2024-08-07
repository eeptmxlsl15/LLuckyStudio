using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BackEnd;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class BackendLogin : BackendLoginBase
{
	[SerializeField] private Image imageID;                   // ID 필드 색상 변경
	[SerializeField] private TMP_InputField inputFieldID;     // ID 필드 텍스트 정보 추출
	[SerializeField] private Image imagePW;                   // PW 필드 색상 변경
	[SerializeField] private TMP_InputField inputFieldPW;     // PW 필드 텍스트 정보 추출
	[SerializeField] private Button btnLogin;                 // 로그인 버튼 (상호작용 가능/불가능)

	/// <summary>
	/// 로그인 버튼을 눌렀을 때 호출
	/// </summary>
	public void OnClickLogin()
	{
		// 깨끗한 UI로 입려간 InputField UI의 색상과 Message 내용 초기화
		ResetUI(imageID, imagePW);

		// InputField 값이 비어있는지 체크
		if (IsFieldDataEmpty(imageID, inputFieldID.text, "ID")) return;
		if (IsFieldDataEmpty(imagePW, inputFieldPW.text, "PW")) return;

		// 로그인 버튼을 연타하지 못하도록 상호작용 비활성화
		btnLogin.interactable = false;

		// 새비에 로그인 요청하는 동안 화면에 호출하는 내용 업데이트
		// 예: 로그인 관련 텍스트 출력, 로딩바 아이콘 회전 등
		StartCoroutine(nameof(LoginProcessRoutine));

		// 뒤끝 서버 로그인 시도
		ResponseToLogin(inputFieldID.text, inputFieldPW.text);
	}

	/// <summary>
	/// 로그인 시도 후 서버로부터 전달받은 message를 기반으로 로직 처리
	/// </summary>
	private void ResponseToLogin(string ID, string PW)
	{
		// 서버에 로그인 요청 (비동기)
		Backend.BMember.CustomLogin(ID, PW, callback =>
		{
			StopCoroutine(nameof(LoginProcessRoutine));

			// 로그인 성공
			if (callback.IsSuccess())
			{
				SetMessage($"환영합니다. \"{inputFieldID.text}\".");
				UnitySceneManager.LoadScene("LobbyScene");
				GameManager.Scene.LoadLOBBY();
				Time.timeScale = 1f;
			}
			// 로그인 실패
			else
			{
				//로그인에 실패했을 때는 다시 로그인을 해야하기 때문에 "로그인" 버튼 상호작용 활성화
				btnLogin.interactable = true;

				string message = string.Empty;

				switch (int.Parse(callback.GetStatusCode()))
				{
					case 401: // 존재하지 않는 아이디, 잘못된 비밀번호
						message = callback.GetMessage().Contains("customId") ? "ID가 존재하지 않습니다." : "잘못된 PW입니다.";
						break;
					case 403: // 유저 or 디바이스 차단
						message = callback.GetMessage().Contains("user") ? "차단된 계정입니다." : "차단된 기기입니다.";
						break;
					case 410: // 탈퇴 진행중
						message = "탈퇴 진행 중입니다.";
						break;
					default:
						message = callback.GetMessage();
						break;
				}

				// StatusCode 401에서 "잘못된 비밀번호 입니다." 일 때
				if (message.Contains("password"))
				{
					GuideForIncorrectlyEnteredData(imagePW, message);
				}
				else
				{
					GuideForIncorrectlyEnteredData(imageID, message);
				}
			}
		});
	}

	private IEnumerator LoginProcessRoutine()
	{
		float time = 0;

		while (true)
		{
			time += Time.deltaTime;

			SetMessage($"로그인 중... {time:F1}초");
			yield return null;
		}
	}
}