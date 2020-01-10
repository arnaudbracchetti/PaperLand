﻿
using System.Collections.Generic;

namespace Paperland.Model
{
    public class ZoneModel
    {
        public int Id { get; private set; }
        private List<ZoneModel> _accecibleZones = new List<ZoneModel>();

        public ZoneModel(int id)
        {
            this.Id = id;
        }


        public void AddAccecibleZone(ZoneModel aZone)
        {
            if (!_accecibleZones.Contains(aZone))
            {
                _accecibleZones.Add(aZone);
                aZone._accecibleZones.Add(this);
            }
        }

        public void RemoveAccecibleZone(ZoneModel aZone)
        {
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
    }
}
