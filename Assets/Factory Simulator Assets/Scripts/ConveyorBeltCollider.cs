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
    public class ConveyorBeltCollider : MonoBehaviour
    {
        private List<Item> items = new List<Item>();
        
        private void OnCollisionEnter(Collision collision)
        {
            Item item = collision.gameObject.GetComponent<Item>();

            // the reason we are checking if item is in list is becuase the container object has multiple colliders which take the 
            // shape of the container. These multiple colliders might add the same container object multiple times depending on how they are positioned
            // this is not good because the same item could be added multiple times
            if (item)
            {
                items.Add(item); // add item to the list of items

                // Add a function that will allow this object to be removed from this list before it is destroyed. This is to prevent a null referecne exception
                item.action_before_destroyed += () => { items.Remove(item); };
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            Item item = collision.gameObject.GetComponent<Item>();

            
            if (item) 
            {
                items.Remove(item);
            }
        }

        public List<Item> getItems()
        {
            return items;
        }

    }
}