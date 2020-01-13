using Paperland.Input;

using UnityEngine;

using Zenject;


namespace Paperland.View
{
    public class ZoneView : ItemView
    {

        private InputController _input;
        private bool _isMousOver = false;
        private bool _isSelected = false;
        public bool IsSelected
        {
            get => _isSelected;
            set => _isSelected = value;
        }


        [Inject]
        public void Consrtuct(InputController anInput)
        {
            _input = anInput;

            _input.EventDrag += OnDrag;
            _input.EventLeftClickDown += OnClickDown;
            _input.EventLeftClickUp += OnClickUp;



        }

        // Start is called before the first frame update
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {

        }


        private void OnClickDown(object o, MouseInfo e)
        {
            /* RaycastHit hit;
             Debug.Log("cast");
             Debug.DrawRay(new Vector3(e.GetWorldPosition().x, e.GetWorldPosition().y, -1), Vector3.forward * 1000, Color.white);
             if (Physics.Raycast(new Vector3(e.GetWorldPosition().x, e.GetWorldPosition().y, -1), Vector3.forward, out hit))
             {
                 IsSelected = true;
                 Debug.Log("hit");
             }*/

        }

        private void OnClickUp(object o, MouseInfo e)
        {
            IsSelected = false;
        }

        private void OnMouseOver()
        {
            Debug.Log("OVER");
            _isMousOver = true;
        }

       

        private void OnMouseExit()
        {
            Debug.Log("OUT");
            _isMousOver = false;
        }

        private void OnMouseDown()
        {
            if (_isMousOver)
                IsSelected = true;
        }

        private void OnMouseUp()
        {
            IsSelected = false;
        }



        private void OnDrag(object o, MouseInfo e)
        {
            Debug.Log("DRAG : " + IsSelected);
            if (IsSelected)
            {
                transform.SetPositionAndRotation(e.GetWorldPosition(), transform.rotation);
            }
        }
    }

    public class ZoneFactory : PlaceholderFactory<ZoneView>
    { }

}
