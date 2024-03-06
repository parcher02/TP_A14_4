using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class gridSlot : MonoBehaviour, IDropHandler
{
  public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<StandardPiece>().placed == false)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<StandardPiece>().placed = true;
            eventData.pointerDrag.GetComponent<StandardPiece>().currency.removeBricks(eventData.pointerDrag.GetComponent<StandardPiece>().cost);
        }
    }
}
