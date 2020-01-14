using Paperland.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class CreateZoneTool : MonoBehaviour, IBeginDragHandler, IDragHandler
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
        _zoneCreator.CreateZone(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        

        Debug.Log(eventData.pointerCurrentRaycast.ToString());
    }
}
