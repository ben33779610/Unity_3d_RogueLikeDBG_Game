using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
	/// <summary>
	/// 實體化BattleManager
	/// </summary>
	public static BattleManager instance;
	[Header("手牌")]
	public List<CardData> HandDeck = new List<CardData>();
	public List<GameObject> HandObject = new List<GameObject>();

    public Animator ani;
	public int crystal;
	public GameObject[] crystalobject;
	public Button btnend;

	public List<CardData> DropDeck = new List<CardData>();
	private int turn; //回合
	private Transform hand;
	private Transform canvas;
	private int crystalTotal;
	private bool myturn;

	private void Start()
	{
		instance = this;
		DeckManager.instance.Startbattle = true;
		canvas = GameObject.Find("畫布").GetComponent<Transform>();
		hand = GameObject.Find("手牌").GetComponent<Transform>();
		crystalTotal = 3;
		crystal = crystalTotal;
	}

    

    /// <summary>
    /// 取得手牌
    /// </summary>
    public IEnumerator GetCard(int count)
	{
		yield return null;
		for (int i = 0; i < count; i++)
		{
			if(DeckManager.instance.BattleDeck.Count == 0)
            {
				ResetDeck();

			}

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
        card.gameObject.GetComponent<HandCard>().ani = ani;

		

	}


	private IEnumerator ThrowCard(int count)
	{

		yield return null;
		for (int i = 0; i < count; i++)
		{
			DropDeck.Add(HandDeck[0]);
			HandDeck.RemoveAt(0);
			
			yield return StartCoroutine(ThrowMove());

		}

	}


	private IEnumerator ThrowMove()
    {
		RectTransform card = HandObject[0].GetComponent<RectTransform>();

		card.SetParent(canvas);



		while (card.anchoredPosition.x > 830)
		{
			card.anchoredPosition = Vector2.Lerp(card.anchoredPosition, new Vector2(831, 0), 0.5f * Time.deltaTime * 50);
			yield return null;
		}
		Destroy(HandObject[0]);
		HandObject.RemoveAt(0);
	}

	/// <summary>
	/// 結束回合
	/// </summary>
	public void EndTurn()
	{
		myturn = false;

		btnend.interactable = false;
		StartCoroutine ( ThrowCard(HandObject.Count));

        Invoke("StartTurn", 3);
	}


	public void StartTurn()
	{
		myturn = true;
		btnend.interactable = true;
		crystal = crystalTotal;
		Crystal();
		StartCoroutine(GetCard(5));
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


	public void ResetDeck()
	{
		for (int i = 0; i < DropDeck.Count; i++)
		{
			DeckManager.instance.BattleDeck.Add( BattleManager.instance.DropDeck[i]);
		}
		BattleManager.instance.DropDeck.Clear();
		DeckManager.instance.CreateCard();
	}

}
