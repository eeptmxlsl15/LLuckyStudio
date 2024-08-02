using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfiniteRandomDebuffUI : MonoBehaviour
{
	[SerializeField] private TMP_Text randomDebuffText1;
	[SerializeField] private TMP_Text randomDebuffText2;

	public void DisplayInfiniteRandomDebuff(BerserkSystemManager.ZodiacSign debuff1, BerserkSystemManager.ZodiacSign debuff2)
	{
		randomDebuffText1.text = $"첫 번째\n디버프 {debuff1}";
		randomDebuffText2.text = $"두 번째\n디버프 {debuff2}";
	}
}
