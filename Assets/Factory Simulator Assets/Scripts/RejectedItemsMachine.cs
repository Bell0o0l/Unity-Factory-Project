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
    public class RejectedItemsMachine : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Item>()) // if collision with an item, destroy that item
            {
                Destroy(other.gameObject);
            }
        }
    }

}
