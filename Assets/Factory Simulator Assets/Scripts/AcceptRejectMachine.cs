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
    [RequireComponent(typeof(LineRenderer))]
    public class AcceptRejectMachine : MonoBehaviour
    {

        [SerializeField]
        private Transform origin_vector;

        [SerializeField]
        private Transform accepted_direction; // accepted items will be pushed in this direction

        [SerializeField]
        private Transform reject_direction; // rejected items will be pushed in this direction

        private LineRenderer line_renderer;


        [SerializeField]
        [Range(1, 3)]
        private float push_strength = 2; // strength of the push


        public int accepted // number of accepted items
        {
            get;
            private set;
        }

        public int rejected // number of items we have rejected
        {
            get;
            private set;
        }


        private void Start()
        {
            line_renderer = GetComponent<LineRenderer>();
            line_renderer.positionCount = 3;
        }


        private void Update()
        {
            line_renderer.SetPosition(0, accepted_direction.transform.position);
            line_renderer.SetPosition(1, origin_vector.position);
            line_renderer.SetPosition(2, reject_direction.transform.position);


            line_renderer.numCornerVertices = 5;
            line_renderer.numCapVertices = 5;
        }


        private void OnTriggerEnter(Collider other)
        {
            Item item = other.GetComponent<Item>();

            if (item)
            {
                if (item.faulty)
                {
                    item.rigid_body.AddForce((reject_direction.transform.position - origin_vector.position) * push_strength, ForceMode.Impulse);

                    rejected += 1;
                }
                else
                {
                    item.rigid_body.AddForce((accepted_direction.transform.position - origin_vector.position) * push_strength, ForceMode.Impulse);

                    accepted += 1;
                }

            }
        }
    }


}