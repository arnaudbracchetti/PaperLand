using System;
using System.Collections;
using System.Collections.Generic;



namespace Paperland.Model
{
    public class ZoneManager
    {
        List<ZoneModel> _zones = new List<ZoneModel>();
        static int _maxId = 0;

        public ZoneModel CreateZone(int id)
        {
            if (id > _maxId) _maxId = id;
            ZoneModel zone = new ZoneModel(id);
            _zones.Add(zone);

            return zone;
        }

        public ZoneModel CreateZone()
        {
            return CreateZone(nextId());
        }

        private int nextId()
        {
            return _maxId++;
        }

        
    }
}
