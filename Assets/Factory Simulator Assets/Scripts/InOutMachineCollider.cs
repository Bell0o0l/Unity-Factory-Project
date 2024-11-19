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
    public class InOutMachineCollider : MonoBehaviour
    {
        private List<Item> items = new List<Item>();

        // when item enters this trigger object, add that item to the Queue of items
        private void OnTriggerEnter(Collider other)
        {
            Item item = other.GetComponent<Item>();

            if (item)
            {
                items.Add(item);
                item.action_before_destroyed += () => items.Remove(item); // remove item from this list before it is destroyed to prevent null exception
            }
           
        }

        public List<Item> getItems()
        {
            return items;
        }

        public Item getFirstItem()
        {
            Item item = items[0];
            items.Remove(items[0]);
            return item;
        }
    }
}