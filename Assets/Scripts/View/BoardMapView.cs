using Paperland.Controller;
using Paperland.Input;
using UnityEngine;
using Zenject;

namespace Paperland.View
{
    public interface IBoardMapView
    {

        void ScrollMap(Vector2 move);
        void ZoomMap(float factor);
        ItemView GetItemUnderPoint(Vector2 point);


    }



    public class BoardMapView : MonoBehaviour, IBoardMapView
    {
        #region attributs
        [SerializeField] private float _zoomSpeed;

        private InputController _input;
        private BoardMapController _controller;

        private bool _dragMap = false;
        #endregion

        #region Construction

        [Inject]
        private void Constructor(InputController anInput, BoardMapController aController)
        {
            _input = anInput;
            _controller = aController;

            _input.EventDrag += OnMouseDrag;
            _input.EventLeftClickDown += OnMouseClickDown;
            _input.EventZoomIn += OnZoomIn;
            _input.EventZoomOut += OnZoomOut;
        }

        // Start is called before the first frame update
        private void Start()
        {

        }

        #endregion



        // Update is called once per frame
        private void Update()
        {

        }



        private void OnMouseDrag(object o, MouseInfo e)
        {

            if (_dragMap)
            {
                ScrollMap(e.GetWorldPositionDelta());
            }
        }

        private void OnMouseClickDown(object o, MouseInfo e)
        {
            if (GetItemUnderPoint(e.GetWorldPosition()) == null)
            {
                _dragMap = true;
            }
            else
            {
                _dragMap = false;
            }
        }

        private void OnZoomIn(object o, MouseInfo e)
        {
            ZoomMap(_zoomSpeed);
        }

        private void OnZoomOut(object o, MouseInfo e)
        {
            ZoomMap(-_zoomSpeed);
        }




        public void ScrollMap(Vector2 move)
        {
            Camera.main.transform.Translate(-move);
        }

        public void ZoomMap(float factor)
        {
            Camera.main.transform.Translate(Vector3.forward * factor * Camera.main.transform.position.z);
        }

        public ItemView GetItemUnderPoint(Vector2 point)
        {
            return null;
        }
    }
}
