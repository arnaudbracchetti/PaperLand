using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Paperland.View
{
    public interface IBoardMapView
    {
        
        void ScrollMap(Vector2 move);
        void ZoomMap(float factor);
        ItemView GetItemUnderPoint(Vector2 point);
    }



    public class MapView : MonoBehaviour, IBoardMapView
    {

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

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
