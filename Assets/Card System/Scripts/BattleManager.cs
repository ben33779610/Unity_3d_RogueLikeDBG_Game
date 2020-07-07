﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BattleManager : MonoBehaviour
{
	/// <summary>
	/// 實體化BattleManager
	/// </summary>
	public static BattleManager instance;
	[Header("手牌")]
	public List<CardData> HandDeck = new List<CardData>();
	public List<GameObject> HandObject = new List<GameObject>();

	public int crystal;
	public GameObject[] crystalobject;
	private bool myturn;

	public List<CardData> DropDeck = new List<CardData>();
	private int turn; //回合
	private Transform hand;
	private Transform canvas;
	private int crystalTotal;

	private void Start()
	{
		instance = this;
		canvas = GameObject.Find("畫布").GetComponent<Transform>();
		hand = GameObject.Find("手牌").GetComponent<Transform>();
		crystalTotal = 3;
		
	}


	/// <summary>
	/// 取得手牌
	/// </summary>
	public IEnumerator GetCard(int count)
	{
		yield return null;
		for (int i = 0; i < count; i++)
		{
			HandDeck.Add(DeckManager.instance.BattleDeck[0]);
			DeckManager.instance.BattleDeck.RemoveAt(0);
			HandObject.Add(DeckManager.instance.BattleObject[0]);
			DeckManager.instance.BattleObject.RemoveAt(0);
			yield return StartCoroutine(MoveCard());

		}
	}

	private IEnumerator MoveCard()
	{
		RectTransform card = HandObject[HandObject.Count - 1].GetComponent<RectTransform>();

		card.SetParent(canvas);
		card.anchorMin = Vector2.one * 0.5f;
		card.anchorMax = Vector2.one * 0.5f;
		card.localScale = Vector3.one * 1.5f;
		while (card.anchoredPosition.x > 501)
		{
			card.anchoredPosition = Vector2.Lerp(card.anchoredPosition, new Vector2(500, 0), 0.5f * Time.deltaTime * 50);
			yield return null;
		}

		

		card.localScale = Vector3.one * 0.5f;
		while (card.anchoredPosition.y > -450)
		{
			card.anchoredPosition = Vector2.Lerp(card.anchoredPosition, new Vector2(0, -451), 0.5f * Time.deltaTime * 50);
			yield return null;
		}

		card.SetParent(hand);

		card.gameObject.AddComponent<HandCard>().card = HandDeck[HandDeck.Count - 1];

		

	}

	/// <summary>
	/// 結束回合
	/// </summary>
	public void EndTurn()
	{
		myturn = false;
	}


	public void StartTurn()
	{
		myturn = true;
		crystal = crystalTotal;
		Crystal();
		StartCoroutine(GetCard(1));
	}

	private void Crystal()
	{
		for (int i = 0; i < crystal; i++)
		{
			crystalobject[i].SetActive(true);
		}
		
	}

	public void UpdateCrystal()
	{
		for (int i = 0; i < crystalobject.Length; i++)
		{
			if (i < crystal) continue;      //如果i < 水晶數量  就跳過此次

			crystalobject[i].SetActive(false);
		}
		
	}

}
