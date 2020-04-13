using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler,IDragHandler,IDropHandler
{

    Transform parentToReturnTo = null;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        print("OnBeginDrag");
        transform.SetParent(transform.parent.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        print("OnDrag");
        transform.position = eventData.position;
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        print("OnDrop");
    }

   
}
