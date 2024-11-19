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
    public class GroundFloor : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            // any item that hits the ground should be destroyed
            if(collision.gameObject.GetComponent<Item>())
            {
                Destroy(collision.gameObject);
            }
        }
    }

}
