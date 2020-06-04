using System.Collections.Generic;
using UnityEngine;


public class BattleManager : MonoBehaviour
{
	/// <summary>
	/// 實體化BattleManager
	/// </summary>
	public static BattleManager instance;
	[Header("手牌資料")]
	public List<CardData> battleDeck = new List<CardData>();
	[Header("手牌遊戲物件")]
	public List<GameObject> Handgameobject = new List<GameObject>();

	private int turn; //回合



}
