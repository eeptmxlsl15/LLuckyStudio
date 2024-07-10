using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chur : BuffTypeObject
{
	public override void Buff()
	{
		player.Heal(10);
	}
}
