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
    public class Container : Item
    {

        private List<Item> items = new List<Item>(); // list of items in this container


        [SerializeField]
        [Range(1, 5)]
        private int total_capacity = 4; // how many items the container can hold

        public bool is_full // if container is full
        {
            get
            {
                return items.Count >= total_capacity;
            }
        }


        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
        }

        // when an item enters this box, add it to the list of items
        private void OnTriggerEnter(Collider other)
        {
            Item item = other.GetComponent<Item>();
            if (item)
            {
                items.Add(item);
            }
        }

        // when an item exits this box, remove it from the list of items
        private void OnTriggerExit(Collider other)
        {
            Item item = other.GetComponent<Item>();
            if (item)
            {
                items.Remove(item);
            }
        }


        public void holdChildItems() // this function prevents physics mess when the container is moved by the package handler
        {
            foreach (Item item in items)
            {
                item.transform.SetParent(transform); // parent all child items to this transform
                item.GetComponent<BoxCollider>().enabled = false; // disable their box colliders
                item.rigid_body.isKinematic = true;
            }
        }


        public int getNumberOfItems()
        {
            return items.Count;
        }
    }
}