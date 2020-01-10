using Paperland.View;
using UnityEngine;
using Zenject;

namespace Paperland.Controller
{
    public class BoardMap 
    {
        [SerializeField] private float _zoomSpeed;

        private InputController _inputController;
        private IBoardMapView _mapView;

        private bool _dragMap = false;


        [Inject]
        private void Construct(IBoardMapView aMapView, InputController anInputController)
        {
            _mapView = aMapView;
            _inputController = anInputController;

            _inputController.EventDrag += OnMouseDrag;
            _inputController.EventLeftClickDown += OnMouseClickDown;
            _inputController.EventZoomIn += OnZoomIn;
            _inputController.EventZoomOut += OnZoomOut;
        }



        private void OnMouseDrag(object o, MouseInfo e)
        {

            if (_dragMap)
            {
                _mapView.ScrollMap(e.GetWorldPositionDelta());
            }
        }

        private void OnMouseClickDown(object o, MouseInfo e)
        {
            if (_mapView.GetItemUnderPoint(e.GetWorldPosition()) == null)
                _dragMap = true;
            else
                _dragMap = false;
        }

        private void OnZoomIn(object o, MouseInfo e)
        {
            _mapView.ZoomMap(_zoomSpeed);
        }

        private void OnZoomOut(object o, MouseInfo e)
        {
            _mapView.ZoomMap(-_zoomSpeed);
        }
    }
}
