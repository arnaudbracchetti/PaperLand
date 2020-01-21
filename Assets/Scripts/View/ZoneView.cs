

using Paperland.Model;

using System.Diagnostics.Contracts;

using UnityEngine;
using UnityEngine.EventSystems;

using Zenject;


namespace Paperland.View
{
    public class ZoneView : ItemView, IDragHandler

    {
        private ZoneModel _data;


        [Inject]
        private void Constructor(ZoneModel data)
        {
            _data = data;
        }


        public void OnDrag(PointerEventData eventData)
        {
            Contract.Requires(eventData != null);

            MoveZone(eventData.position);
            _data.SetPosition(transform.position);
        }

        private void MoveZone(Vector2 screenPos)
        {
            Vector3 pos = screenPos;
            pos.z = -Camera.main.transform.position.z;

            pos = Camera.main.ScreenToWorldPoint(pos); //World
            pos.z = 0;

            transform.position = pos;
        }

    }

    public class ZoneFactory : PlaceholderFactory<ZoneView>
    { }

}
