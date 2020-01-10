using UnityEngine;
using System.Collections;

namespace Paperland.View
{
    abstract public class ItemView : MonoBehaviour
    {
        public void SetCenterPosition(Vector2 pos)
        {
            transform.position = new Vector3(pos.x, pos.y, 0);
        }

    }
}
