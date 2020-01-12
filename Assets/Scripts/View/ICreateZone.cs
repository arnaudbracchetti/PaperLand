using UnityEngine;
using System.Collections;

namespace Paperland.View
{
    public interface ICreateZone
    {

        ZoneView CreateZone(Vector2 pos);
    }
}
