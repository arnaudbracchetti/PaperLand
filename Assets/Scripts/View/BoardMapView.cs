using Paperland.Controller;
using Paperland.Inputs;

using System.Diagnostics.Contracts;

using UnityEngine;
using UnityEngine.EventSystems;

using Zenject;

namespace Paperland.View
{
    



    public class BoardMapView : MonoBehaviour, IDragHandler, IInitializePotentialDragHandler, IScrollHandler
    {
        #region attributs
        [SerializeField] private float _zoomSpeed;





        private Vector3 _camPosOrigin;
        #endregion

       

        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
            _camPosOrigin = eventData.pressEventCamera.transform.position;
        }



        public void OnDrag(PointerEventData eventData)
        {
            Contract.Requires(eventData != null);

            Vector3 pos = eventData.position;
            Vector3 posOrigin = eventData.pressPosition;
            pos.z = -eventData.pressEventCamera.transform.position.z;
            posOrigin.z = -eventData.pressEventCamera.transform.position.z;

            pos = eventData.pressEventCamera.ScreenToWorldPoint(pos);
            posOrigin = eventData.pressEventCamera.ScreenToWorldPoint(posOrigin);

            Camera.main.transform.position = _camPosOrigin - (pos - posOrigin);

        }

        public void OnScroll(PointerEventData eventData)
        {
            Debug.Log(eventData.scrollDelta);
            if (eventData.scrollDelta == Vector2.up)
            {
                ZoomMap(_zoomSpeed);
            }
            else
            {
                ZoomMap(-_zoomSpeed);
            }
        }

       



        public void ScrollMap(Vector2 move)
        {
            Camera.main.transform.Translate(-move);
        }

        public void ZoomMap(float factor)
        {
            if ((factor < 0 && Camera.main.transform.position.z < -1) || (factor > 0 && Camera.main.transform.position.z > -30))
            {
                Camera.main.transform.Translate(Vector3.forward * factor * Camera.main.transform.position.z);
            }
        }



    }
}
