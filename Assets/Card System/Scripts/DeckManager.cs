using System.Collections.Generic;
using UnityEngine;


public class DeckManager : MonoBehaviour
{
	public static DeckManager instance;

	public List<CardData> Deck = new List<CardData>();

	//戰鬥牌組
	public List<CardData> BattleDeck = new List<CardData>();


	[Header("牌組" +	"內容")]
	public Transform deckcontent;


	private void Start()
	{
		instance = this;

	}
	/// <summary>
	/// 初始化牌組
	/// </summary>
	private void InitialDeck()
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
	}


	

	/// <summary>
	/// 洗牌
	/// </summary>
	private void Shuffle()
	{
		for (int i = 0; i < BattleDeck.Count; i++)
		{
			CardData original = BattleDeck[i];
			int r = Random.Range(0, BattleDeck.Count);
			BattleDeck[i] = BattleDeck[r];
			BattleDeck[r] = original;

		}		
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
}
