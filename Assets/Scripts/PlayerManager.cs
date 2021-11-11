using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        FindObjectOfType<PlayerController>().setSpaceShipStat(true);
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        FindObjectOfType<PlayerController>().setSpaceShipStat(false);
    }
}
