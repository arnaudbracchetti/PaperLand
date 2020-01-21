
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using Zenject;

namespace Paperland.Model
{
    public class ZoneModel
    {
        static private int _maxId = 0;
        private int _id=0;
        public int Id { 
            get { return _id; }
            private set {
                if (value < _maxId)
                {
                    _maxId = value;
                }

                _id = value;
            }
        }

        private List<ZoneModel> _accecibleZones = new List<ZoneModel>();
        private Vector3 position;

        public ZoneModel(int id)
        {
            this.Id = id;
        }

       

        public void SetPosition(Vector2 pos)
        {
            position = pos;
        }

        public void AddAccecibleZone(ZoneModel aZone)
        {

            Contract.Requires(aZone != null);

            if (!_accecibleZones.Contains(aZone))
            {
                _accecibleZones.Add(aZone);
                aZone._accecibleZones.Add(this);
            }
        }

        public void RemoveAccecibleZone(ZoneModel aZone)
        {
            Contract.Requires(aZone != null);

            _accecibleZones.Remove(aZone);
            aZone._accecibleZones.Remove(this);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ZoneModel z))
                return false;
            else
                return z.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public class ZoneFactory : PlaceholderFactory<ZoneModel>
        { }

        public class CustomZoneFactory : IFactory<ZoneModel>
        {
            ZoneManager _zoneManager;

            CustomZoneFactory(ZoneManager zm)
            {
                _zoneManager = zm;
            }

            public ZoneModel Create()
            {
                return _zoneManager.CreateZone();
            }
        }
    }
}
