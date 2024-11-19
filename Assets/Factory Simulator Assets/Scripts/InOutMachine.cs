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
    public class InOutMachine : MonoBehaviour
    {

        [SerializeField]
        protected InOutMachineCollider input_collider;


        [SerializeField]
        protected Transform output_transform; // the position from which we will output the item


        [SerializeField]
        protected Vector3 output_vector; // the vector of the force we will apply to the item


        public int total_items_processed // number of items that we have processed
        {
            get;
            private set;
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            if (input_collider.getItems().Count > 0)
            {
                processItems();
            }
        }


        protected void processItems()
        {
            Item output_item = input_collider.getFirstItem(); // get first item in the list

            output_item.transform.position = output_transform.position;

            modifyItem(output_item);

            output_item.rigid_body.AddForce(output_vector, ForceMode.Impulse);

        }

        protected void modifyItem(Item item) // increment item stage and increment the total items processed by 1
        {
            item.incrementItemStage();

            item.transform.rotation = Quaternion.identity;

            total_items_processed += 1;
        }

    }


}