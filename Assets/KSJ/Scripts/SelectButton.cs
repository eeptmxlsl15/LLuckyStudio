using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
   public enum Item
	{
		Effect,
		Wallpaper
	}
	public Item item;
	public void OnClick(int id)
	{
		switch (item)
		{
			case Item.Effect:
				DataManager.Instance.effectID = id;
				break;
			case Item.Wallpaper:
				DataManager.Instance.wallpaper = id;
				break;
		}
		
	}


}
