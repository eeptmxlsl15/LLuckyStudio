using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossDebuffUI : MonoBehaviour
{
	[SerializeField] private TMP_Text debuffText;

	private void Start()
	{
		DisplayBossDebuff(GameManager.Instance.BossDebuff);
	}

	public void DisplayBossDebuff(BerserkSystemManager.ZodiacSign debuff)
	{
		debuffText.text = $"현재 보스 디버프: {debuff}";
	}

	
}
