﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
	public static DeckManager instance;

	public List<CardData> Deck = new List<CardData>();

	//戰鬥牌組
	public List<CardData> BattleDeck = new List<CardData>();
	public List<GameObject> BattleObject = new List<GameObject>();
	




	[Header("牌組" +	"內容")]
	public Transform deckcontent;


	private void Start()
	{
		instance = this;

	}
	/// <summary>
	/// 初始化牌組
	/// </summary>
	public void InitialDeck()
	{
		for (int i = 0; i < 5; i++)
		{
			Deck.Add(GetCard.instance.cards[0]);
		}
		for (int i = 0; i < 5; i++)
		{
			Deck.Add(GetCard.instance.cards[1]);
		}
		BattleDeck = Deck;
		Shuffle();
	}



	/// <summary>
	/// 建立卡牌在洗牌區
	/// </summary>
	private void CreateCard()
	{
		for (int i = 0; i < BattleDeck.Count; i++)
		{
			Transform temp = Instantiate(GetCard.instance.cardobject, deckcontent).transform;
			CardData card = Deck[i];
			temp.Find("名稱").GetComponent<Text>().text = card.name.ToString();
			temp.Find("描述").GetComponent<Text>().text = card.description.ToString();
			temp.Find("消耗").GetComponent<Text>().text = card.cost.ToString();
			temp.Find("血量").GetComponent<Text>().text = card.hp.ToString();
			temp.Find("攻擊").GetComponent<Text>().text = card.attack.ToString();
			//temp.Find("卡圖").GetComponent<Image>().sprite = Resources.Load<Sprite>(card.file);
			BattleObject.Add(temp.gameObject);
		}
		
	}


	/// <summary>
	/// 洗牌
	/// </summary>
	public void Shuffle()
	{
		for (int i = 0; i < BattleDeck.Count; i++)
		{
			CardData original = BattleDeck[i];
			int r = Random.Range(0, BattleDeck.Count);
			BattleDeck[i] = BattleDeck[r];
			BattleDeck[r] = original;

		}
		CreateCard();
	}

	public void AddCard(int index)
	{


		//取得卡牌資訊
		CardData card = GetCard.instance.cards[index - 1];
		Deck.Add(card);

			
		

	}

	/// <summary>
	/// 刪除卡牌
	/// </summary>
	public void DeleteCard(int index)
	{

		//移除卡牌
		Deck.Remove(GetCard.instance.cards[index - 1]);
	}

	public void StartBattle()
	{

		StartCoroutine( BattleManager.instance.GetCard(4));
		
	}
}
