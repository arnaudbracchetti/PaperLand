using Paperland.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class CreateZoneTool : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerEnterHandler, IInitializePotentialDragHandler
{
    private float threshold = 9; //carré du nombre de pixels déclanchant la création d'un élément
    private ICreateZone _zoneCreator;
    
    [Inject]
    void constructor(ICreateZone cz)
    {
        _zoneCreator = cz;
    }
   

    public void OnDrag(PointerEventData eventData)
    {
       
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("DRAG");
    }


    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        ZoneView newZone = _zoneCreator.CreateZone(eventData.pointerCurrentRaycast.worldPosition);

        eventData.pointerDrag = newZone.gameObject;
        Debug.Log(eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("ENTER");
    }
}
