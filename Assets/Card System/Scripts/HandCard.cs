﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	private Vector3 origin; //初始位置
	private bool isdrop;	//是否丟出

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
