using Paperland.Controller;
using Paperland.Inputs;

using System.Diagnostics.Contracts;

using UnityEngine;
using UnityEngine.EventSystems;

using Zenject;

namespace Paperland.View
{
    public interface IBoardMapView
    {

        void ScrollMap(Vector2 move);
        void ZoomMap(float factor);
        ItemView GetItemUnderPoint(Vector2 point);


    }



    public class BoardMapView : MonoBehaviour, IBoardMapView, IDragHandler, IInitializePotentialDragHandler
    {
        #region attributs
        [SerializeField] private float _zoomSpeed;

        private InputController _input;
        private BoardMapController _controller;

        private bool _dragMap = false;
        private Vector3 _dragOrigin, _nextCamPos;
        #endregion

        #region Construction

        [Inject]
        private void Constructor(InputController anInput, BoardMapController aController)
        {
            _input = anInput;
            _controller = aController;

            /*
                        _input.EventDrag += OnMouseDrag;
                        _input.EventLeftClickDown += OnMouseClickDown;
                        _input.EventZoomIn += OnZoomIn;
                        _input.EventZoomOut += OnZoomOut;*/
        }

        // Start is called before the first frame update
        private void Start()
        {

        }

        #endregion

        Vector2 pos, pos2;

        // Update is called once per frame
        private void LateUpdate()
        {
           
            
        }



        public void OnDrag(PointerEventData eventData)
        {
           // Contract.Requires(eventData != null);



            /*Vector3 pos = eventData.position;
            pos.z = -Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);
            pos.z = -Camera.main.transform.position.z;*/
            pos = eventData.position;
            pos2 = eventData.pressPosition;

           

            Vector3 wpos = eventData.pressEventCamera.ScreenToWorldPoint(new Vector3(pos.x, pos.y, -Camera.main.transform.position.z));//Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, -Camera.main.transform.position.z));
            Vector3 wpos2 = eventData.pressEventCamera.ScreenToWorldPoint(new Vector3(pos2.x, pos2.y, -Camera.main.transform.position.z));//Camera.main.ScreenToWorldPoint(new Vector3(pos2.x, pos2.y, -Camera.main.transform.position.z));
            Vector3 newPos = (wpos - wpos2);
            //newPos.z = Camera.main.transform.position.z;


            Camera.main.transform.position = _dragOrigin - newPos;
            _nextCamPos = -(pos - pos2);
            //ScrollMap(Camera.main.ScreenToWorldPoint(new Vector3(eventData.delta.x, eventData.delta.y, -Camera.main.transform.position.z)));
        }
        /*
        private void OnMouseDrag(object o, MouseInfoEventArgs e)
        {

            if (_dragMap)
            {
               // ScrollMap(e.GetWorldPositionDelta());
            }
        }

        private void OnMouseClickDown(object o, MouseInfoEventArgs e)
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
        */
        private void OnZoomIn(object o, MouseInfoEventArgs e)
        {
            ZoomMap(_zoomSpeed);
        }

        private void OnZoomOut(object o, MouseInfoEventArgs e)
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

        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
            _dragOrigin = eventData.pressEventCamera.transform.position;
        }
    }
}
