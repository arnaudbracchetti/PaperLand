using Paperland.View;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Paperland.Controller
{
    public class BoardMapController 
    {


        [SerializeField] private float _moveDistance;



        
        private ZoneFactory _zoneFactory;
        private List<ZoneView> _zones = new List<ZoneView>();
        

        [Inject]
        void construct( ZoneFactory aZoneFactory)
        {
            
            _zoneFactory = aZoneFactory;


           
        }

        void CreateZone(Vector3 pos)
        {
            ZoneView aZone = _zoneFactory.Create();
            aZone.SetCenterPosition(pos);
            _zones.Add(aZone);
        }

        /*
        void OnClickDown(object o, MouseInfo e)
        {
            _mousePosOnDown = e.GetScreenPostion();
        }

        void OnClickUp(object o, MouseInfo e)
        {
            float moveDistance = (_mousePosOnDown - e.GetScreenPostion()).magnitude;
            if (moveDistance < _moveDistance)
            {
                

            }
        }
        */


    }
}
