using UnityEngine;
using UnityEngine.UI;

public class DeckObject : MonoBehaviour
{
	public int index;



	public void AddCard()
	{
		DeckManager.instance.AddCard(index);
	}
	public void DeleteCard()
	{
		DeckManager.instance.DeleteCard(index);
	}
}
