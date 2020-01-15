using UnityEngine;
using System.Collections;

namespace Paperland.View
{
    public interface ICreateZone
    {

        ZoneView CreateZone(Vector3 pos);
    }
}
