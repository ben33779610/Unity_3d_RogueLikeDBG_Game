using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

	public CardData card;	//此卡的資料




	private Vector3 origin; //初始位置
	private bool isdrop;	//是否丟出
    private Transform pos;

    private void Start()
    {
        pos = GameObject.Find("生成位置").GetComponent<Transform>();   
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

		//原始座標
		origin = transform.position;

        
    }

    public void OnDrag(PointerEventData eventData)
    {

        transform.position = eventData.position;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
		if (isdrop)
		{

			BattleManager.instance.DropDeck.Add(card);


            BattleManager.instance.HandDeck.Remove(card);
            BattleManager.instance.DropDeck.Add(card);
            GameObject temp = Instantiate(card.obj, pos);
            //temp.AddComponent<Monster>().data.atk = card.attack;
            //temp.GetComponent<Monster>().data.hp = card.hp;


            Destroy(gameObject);
		}
		else
		{
			//回到原始座標
			transform.position = origin;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		isdrop = true;
	}
	private void OnCollisionExit(Collision collision)
	{
		isdrop = false;
	}


}
