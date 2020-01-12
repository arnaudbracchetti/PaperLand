using UnityEngine;
using System.Collections;
using Paperland.View;
using Zenject;

public class GameManager : MonoBehaviour, ICreateZone
{
    private ZoneFactory _zoneFactory;

    [Inject]
    void Constructor(ZoneFactory zf)
    {
        _zoneFactory = zf;
    }

    public ZoneView CreateZone(Vector2 pos)
    {
        ZoneView aZone = _zoneFactory.Create();
        aZone.SetCenterPosition(pos);
        aZone.IsSelected = true;
        //_zones.Add(aZone);

        return aZone;
    }

   
}
