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

    public class PusherMachine : MonoBehaviour
    {
        [SerializeField]
        private Transform origin_vector;

        [SerializeField]
        private Transform push_direction; // the push will happen in this direction

        private LineRenderer line_renderer;

        [SerializeField]
        [Range(1, 3)]
        private float push_strength = 2; // strength of the push

        private void Start()
        {
            line_renderer = GetComponent<LineRenderer>();
        }


        private void Update()
        {
            // use line renderer to show push direction
            line_renderer.SetPositions(new Vector3[] { origin_vector.position, push_direction.transform.position }) ;
        }
        private void OnTriggerEnter(Collider other)
        {
            Item item = other.GetComponent<Item>();
            if (item) // add impulse force to the item on collision
            {
                item.rigid_body.AddForce((push_direction.transform.position - origin_vector.position) * push_strength, ForceMode.Impulse);

            }
        }
    }

}
