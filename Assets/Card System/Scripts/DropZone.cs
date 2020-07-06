using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour
{

	Image al;

	private void Start()
	{
		al = GetComponent<Image>();
	}
	
	
	
	private void OnCollisionEnter(Collision collision)
	{
		if (tag == "怪物區域")
		{
			var tempcolor = al.color;
			tempcolor = Color.green;
			tempcolor.a = 0.3f;
			al.color = tempcolor;
		}
		Debug.Log("OnPointerEnter");
	}

	private void OnCollisionExit(Collision collision)
	{
		
	}



}
