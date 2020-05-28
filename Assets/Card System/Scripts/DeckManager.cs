using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
public class DeckManager : MonoBehaviour
{
	public static DeckManager instance;

	public List<CardData> Deck = new List<CardData>();
<<<<<<< Updated upstream
=======

	[Header("套牌內容")]
	public Transform deckcontent;


	private void Start()
	{
		instance = this;

	}




	/// <summary>
	/// 洗牌
	/// </summary>
	private void Shuffle()
	{
		for (int i = 0; i < Deck.Count; i++)
		{
			CardData original = Deck[i];
			int r = Random.Range(0, Deck.Count);
			Deck[i] = Deck[r];
			Deck[r] = original;

		}		
	}
>>>>>>> Stashed changes
}
