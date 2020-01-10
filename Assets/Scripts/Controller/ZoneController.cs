using UnityEngine;
using System.Collections;
using Paperland.Model;
using Zenject;
using Paperland.View;

//using Paperland.Controller;



namespace Paperland.Controller
{

   
    public class ZoneController : MonoBehaviour
    {
        [SerializeField] private float _moveDistance;

        

        private IBoardMapView _mapView;
        private InputController _inputController;
        private ZoneFactory _zoneFactory;

        Vector2 _mousePosOnDown;

        [Inject]
        void construct(IBoardMapView aMapView, InputController anInputController, ZoneFactory aZoneFactory)
        {
            _mapView = aMapView;
            _inputController = anInputController;
            _zoneFactory = aZoneFactory;


            _inputController.EventLeftClickDown += OnClickDown;
            _inputController.EventLeftClickUp += OnClickUp;
        }


        void OnClickDown(object o, MouseInfo e)
        {
            _mousePosOnDown = e.GetScreenPostion();
        }

        void OnClickUp(object o, MouseInfo e)
        {
            float moveDistance = (_mousePosOnDown - e.GetScreenPostion()).magnitude;
            if (moveDistance < _moveDistance)
            {
                ZoneView aZone = _zoneFactory.Create();
                aZone.SetCenterPosition(e.GetWorldPosition());
                  
            }
        }
    }
}
