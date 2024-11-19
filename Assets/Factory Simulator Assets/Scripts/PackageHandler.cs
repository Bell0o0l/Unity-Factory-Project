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
    public class PackageHandler : MonoBehaviour
    {

        private Container packaging_container; // current packaging container


        [SerializeField]
        private Container package_container_prefab; // prefab for container


        [SerializeField]
        private Transform input_position; // position to spwawn container

        [SerializeField]
        private Transform output_position; // position that container will be placed at when full


        public int current_items // items in current container
        {
            get;
            private set;
        }

        // Start is called before the first frame update
        void Start()
        {
            packaging_container = Instantiate(package_container_prefab, input_position.position, Quaternion.identity); // at start, spwawn a new packaging container at input position

        }

        // Update is called once per frame
        void Update()
        {

            if (packaging_container == null) // if there is no packaging container, then spawn one
            {
                packaging_container = Instantiate(package_container_prefab, input_position.position, Quaternion.identity); // spwawn a new packaging container at input position

                current_items = 0;
            }
            else
            {

                if (packaging_container.is_full)
                {

                    packaging_container.holdChildItems();

                    // we set kinematic to true, set position, then set kinematic to false. If we do not set kinematic to true before moving the position, we might get messy physics behaviour

                    packaging_container.rigid_body.isKinematic = true;

                    packaging_container.transform.position = output_position.position;

                    packaging_container.rigid_body.isKinematic = false;

                    packaging_container = null;

                }
                else
                {
                    packaging_container.transform.position = input_position.position;
                    packaging_container.rigid_body.isKinematic = true;
                }


                if (packaging_container) 
                    current_items = packaging_container.getNumberOfItems(); // get number of items from container
            }


        }


        private void OnTriggerEnter(Collider other)
        {

            Container container = other.GetComponent<Container>();
            if (container)
            {
                packaging_container = other.GetComponent<Container>(); // current packaging container is the one that enters this object's trigger collider
            }
        }
    }


}