﻿using Paperland.View;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class CreateZoneTool : MonoBehaviour, IInitializePotentialDragHandler, IDragHandler
{
    
    private ICreateZone _zoneCreator;
    
    [Inject]
    void Constructor(ICreateZone cz)
    {
        _zoneCreator = cz;
    }
   



    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        Contract.Requires(eventData != null);


        ZoneView newZone = _zoneCreator.CreateZone(eventData.pointerCurrentRaycast.worldPosition);

        eventData.pointerDrag = newZone.gameObject;
      
    }

   


    public void OnDrag(PointerEventData eventData)
    {
        // doit être présent pour que OnInitializePotentialDrag soit appelée
    }
}
