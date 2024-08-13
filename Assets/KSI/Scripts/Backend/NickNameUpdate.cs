using BackEnd;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NickNameUpdate : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI textNickname;
	//[SerializeField] private TextMeshProUGUI textUID;
	[SerializeField] private TMP_InputField inputFieldUID;

	public void UpdateNickname()
	{
		// 닉네임이 없으면 gamer_id를 출력하고, 닉네임이 있으면 닉네임 출력
		textNickname.text = UserInfo.Data.nickname == null ?
							UserInfo.Data.gamerId : UserInfo.Data.nickname;

		// gamer_id 출력
		inputFieldUID.text = Backend.UID;
		inputFieldUID.readOnly = true;
	}
}
