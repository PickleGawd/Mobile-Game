using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour {

	private int spentCoins = 0;
	private int toBuy = 1;

	public void amountOfCoins(int coins)
	{
		spentCoins = coins;
	}

	public void amount(int amount)
	{
		toBuy = amount;
	}

	public void BuyItem(string item)
	{
		BuyItem(item, spentCoins, toBuy);
	}

	public void BuyItem(string item, int coins, int amount = 1)
	{
		coins *= amount;

		if (PlayerPrefs.GetInt("coins") - coins < 0)
		{
			Debug.Log("Not enough coins");
		}
		else
		{
			PlayerPrefs.SetInt(item, PlayerPrefs.GetInt(item) + amount);
			PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - coins);

			Debug.Log("Successfully purchased " + amount + " " + item + "(s). Total is now " + PlayerPrefs.GetInt(item));
		}
		
	}
}
