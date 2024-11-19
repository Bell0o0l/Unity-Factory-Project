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

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class Item : MonoBehaviour
    {

        public Rigidbody rigid_body
        {
            get;
            private set;
        }
       

        [SerializeField]
        protected GameObject[] item_stages; // stages for this item. this helps to give the illusion that the item is being processed or transformed.
                                            // These gameobjects contain sequential stages that this item will go though

        private int item_stage; // current stage for this item

        public bool faulty // if this item is faulty
        {
            get;
            set;
        }


        [SerializeField]
        private GameObject missing_item; // All faulty items will not have this part

        public System.Action action_before_destroyed; // function that will be called before this item is destroyed



        protected virtual void Start()
        {
            rigid_body = GetComponent<Rigidbody>();
        }


        // Update is called once per frame
        protected virtual void Update()
        {
            updateItemStates();

            updateFaultiness();
        }

        private void updateFaultiness()
        {
            if (missing_item)
            {
                missing_item.SetActive(!faulty);
            }

        }

        private void updateItemStates() // set only one gameobject (in the stages array) visible depending on the item stage
        {
            if (item_stages.Length > 0)
            {
                for (int i = 0; i < item_stages.Length; i++)
                {
                    item_stages[i].SetActive(i == item_stage);
                }
            }
        }

        public void incrementItemStage() // this function will be called when the item is "processed" by the in out machine
        {
            if (item_stage < item_stages.Length - 1)
            {
                item_stage += 1;
            }
        }

        private void OnDestroy()
        {
            if (action_before_destroyed != null)
            {
                action_before_destroyed.Invoke();
            }
        }
    }



}