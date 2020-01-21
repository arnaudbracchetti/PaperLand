using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Paperland.View;
using Zenject;
using System.Diagnostics.Contracts;

namespace Paperland.Inputs
{
    public class InputController : MonoBehaviour
    {
        

        private MouseInfoEventArgs _data = new MouseInfoEventArgs(Vector2.zero, false);


        public event EventHandler<MouseInfoEventArgs> EventDrag;
        public event EventHandler<MouseInfoEventArgs> EventMove;
        public event EventHandler<MouseInfoEventArgs> EventLeftClickUp;
        public event EventHandler<MouseInfoEventArgs> EventLeftClickDown;
        public event EventHandler<MouseInfoEventArgs> EventZoomIn;
        public event EventHandler<MouseInfoEventArgs> EventZoomOut;


        public void OnMouseClickUp(InputAction.CallbackContext context)
        {
            if (context.performed)
            {

                _data.clicked = false;
                EventLeftClickUp?.Invoke(this, new MouseInfoEventArgs(_data));


            }
        }

        public void OnMouseClickDown(InputAction.CallbackContext context)
        {
            if (context.performed)
            {

                _data.clicked = true;
                EventLeftClickDown?.Invoke(this, new MouseInfoEventArgs(_data));

            }

        }

        public void OnMouseMove(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _data.SetScreenPosition(context.ReadValue<Vector2>());

                if (_data.clicked)
                {
                    EventDrag?.Invoke(this, new MouseInfoEventArgs(_data));

                }

                EventMove?.Invoke(this, new MouseInfoEventArgs(_data));

            }

        }

        public void OnZoom(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (context.ReadValue<float>() > 0)
                    EventZoomIn?.Invoke(this, new MouseInfoEventArgs(_data));
                else
                    EventZoomOut?.Invoke(this, new MouseInfoEventArgs(_data));

            }
        }
    }

    public class MouseInfoEventArgs : EventArgs
    {

        public bool clicked;

        private Vector2 _screenPostion = Vector2.zero;
        private Vector2 _oldScreenPostion = Vector2.zero;
        private Vector2 _worldPositionCach = Vector2.zero;
        private bool _cachIsDirty = true;

        public MouseInfoEventArgs(Vector2 screenPos, bool clicked)
        {
            SetScreenPosition(screenPos);
            _oldScreenPostion = _screenPostion;
            this.clicked = clicked;
        }

        public MouseInfoEventArgs(MouseInfoEventArgs m)
        { 

           Contract.Requires(m != null);

            clicked = m.clicked;
            _screenPostion = new Vector2(m._screenPostion.x, m._screenPostion.y);
            _oldScreenPostion = m._oldScreenPostion;
            _cachIsDirty = true;
        }

        public void SetScreenPosition(Vector2 screenPos)
        {
            _oldScreenPostion = _screenPostion;
            _screenPostion = screenPos;
            _cachIsDirty = true;


        }

        public Vector2 GetScreenPostion()
        {
            return _screenPostion;
        }

        public Vector2 GetWorldPosition()
        {

            if (_cachIsDirty)
            {
                _cachIsDirty = false;
                _worldPositionCach = convertScreenToWorld(_screenPostion);
            }

            return _worldPositionCach;
        }

        public Vector2 GetScreenPositionDelta()
        {
            return _screenPostion - _oldScreenPostion;
        }

        public Vector2 GetWorldPositionDelta()
        {
            return GetWorldPosition() - convertScreenToWorld(_oldScreenPostion);
        }

        private Vector2 convertScreenToWorld(Vector2 screenPos)
        {
            Vector3 pos = new Vector3(screenPos.x, screenPos.y, -Camera.main.transform.position.z);
            pos = Camera.main.ScreenToWorldPoint(pos);

            return pos;
        }
    }
}