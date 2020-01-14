

using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;


namespace Paperland.View
{
    public class ZoneView : ItemView, IDragHandler, IBeginDragHandler, IEndDragHandler

    {

        //private InputController _input;
        private bool _isDrag = false;
        private bool _isSelected = false;
        public bool IsSelected
        {
            get => _isSelected;
            set => _isSelected = value;
        }

  
        public void OnDrag(PointerEventData eventData)
        {
            if (_isDrag)
            {

                Vector3 pos;
                pos = eventData.position; // Screen
                pos.z = -Camera.main.transform.position.z;
                
                pos = Camera.main.ScreenToWorldPoint(pos); //World
                pos.z = 0;
                
                transform.position = pos;
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _isDrag = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _isDrag = false;
        }



        //private void OnDrag(object o, MouseInfo e)
        //{
        //    //Debug.Log("DRAG : " + IsSelected);

        //}
    }

    public class ZoneFactory : PlaceholderFactory<ZoneView>
    { }

}
