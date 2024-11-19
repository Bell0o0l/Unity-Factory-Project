/*
 * 
 * Developed by Olusola Olaoye, 2023
 * 
 * To only be used by those who purchased from the Unity asset store
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



namespace FactorySimulator
{

    [RequireComponent(typeof(BoxCollider))]
    public class Button3D : MonoBehaviour
    {
        public bool is_clicked_on
        {
            get;
            private set;
        }

        private System.Action action_when_clicked;


        private float button_size_change_for_interaction = 1.2f; // for animation purpose, will determine how 3d button will change size die to click
        public void setClickAction(System.Action action)
        {
            action_when_clicked += action;
        }

        private void OnMouseOver()
        {
            is_clicked_on = Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() ; // button is clicked on if mouse is over this object and the left mouse button is down 
        }


        private void Update()
        {
            if (is_clicked_on && action_when_clicked != null)
            {
                action_when_clicked.Invoke(); //invoke function when button object is clicked on
            }
        }


        // for animation and interaction purpose, when you click on button it should get smaller
        private void OnMouseDown()
        {
            transform.localScale /= button_size_change_for_interaction;
        }

        // for animation and interaction purpose, after you click on button it should return to normal size
        private void OnMouseUp()
        {
            transform.localScale *= button_size_change_for_interaction;
        }
    }


}