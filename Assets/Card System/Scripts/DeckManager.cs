using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
	public static DeckManager instance;

	public List<CardData> Deck = new List<CardData>();
}
