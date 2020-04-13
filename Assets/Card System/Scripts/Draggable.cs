using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{

    Transform parentToReturnTo = null;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        print("OnBeginDrag");
		parentToReturnTo = transform.parent;
        transform.SetParent(transform.parent.parent);

		GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        print("OnDrag");
        transform.position = eventData.position;
        
    }

	public void OnEndDrag(PointerEventData eventData)
	{
		transform.SetParent(parentToReturnTo);
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
}
