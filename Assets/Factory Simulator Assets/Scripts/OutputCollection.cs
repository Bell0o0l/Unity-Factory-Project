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



namespace FactorySimulator
{
    [RequireComponent(typeof(BoxCollider))]
    public class OutputCollection : MonoBehaviour
    {
        public int items_collected
        {
            get;
            private set;
        }

       
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Item>()) // if a container enters this trigger
            {

                items_collected += 1; // add to items collected

                Destroy(other.gameObject, 1); // destroy object after 1 second
            }
        }

    }

}
