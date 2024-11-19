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
    public class ConveyorBelt : MonoBehaviour
    {

        [SerializeField]
        private Transform[] paths; // array of transforms to show the path that items will follow


        [SerializeField]
        private ConveyorBeltCollider conveyor_belt_collider; // access to the conveyor belt collider to help us know the items on this conveyor belt


        [SerializeField]
        private bool constant_speed; // if items should move at constant speed or based on how far the paths are separated from each other


        [SerializeField]
        [Range(0.01f, 0.04f)]
        private float movement_speed = 0.03f; // speed for the items to move

        // if items in the conveyor belt should go in reverse order
        public bool reverse;

        private Renderer belt_renderer; // access to the renderer of the conveyor belt

        [SerializeField]
        [Range(-2,2)]
        private float conveyor_belt_scale_x = 1; // allows us to change the UV of the conveyor belt to give the animation of the diection the belt is moving
        
        private void Start()
        {
            belt_renderer = conveyor_belt_collider.GetComponent<Renderer>();
        }

        void FixedUpdate()
        {

            animateBeltTexture();

            if(reverse)
            {
                reverseMovement();
            }
            else
            {
                forwardMovement();
            }

        }

        private void forwardMovement()
        {
            for (int i = 0; i < conveyor_belt_collider.getItems().Count; i++) // for every item on this conveyor belt
            {
                if (getClosestPathIndexToTransform(conveyor_belt_collider.getItems()[i]) + 1 < paths.Length) // if the item is not at the last path transform
                {
                    // move object towards the next transform on the path
                    // if constant speed? then normalise the vector so that the magnitude of the vector will always be 1. Good for consistency
                    conveyor_belt_collider.getItems()[i].transform.position += constant_speed
                                                ?
                                                (paths[getClosestPathIndexToTransform(conveyor_belt_collider.getItems()[i]) + 1].position - conveyor_belt_collider.getItems()[i].transform.position).normalized * movement_speed
                                                :
                                                (paths[getClosestPathIndexToTransform(conveyor_belt_collider.getItems()[i]) + 1].position - conveyor_belt_collider.getItems()[i].transform.position) * movement_speed;
                }
            }

            //belt_renderer.material.SetTextureScale("_MainTex", new Vector2(1, -1));
            belt_renderer.material.mainTextureScale = new Vector2(1, -1);
        }
        
        private void reverseMovement()
        {
            for (int i = conveyor_belt_collider.getItems().Count - 1; i >= 0 ; i--) // for every item on this conveyor belt
            {
                if (getClosestPathIndexToTransform(conveyor_belt_collider.getItems()[i]) > 0) // if the item is not at the first path transform
                {
                    // move object towards the previous transform on the path
                    // if constant speed? then normalise the vector so that the magnitude of the vector will always be 1. Good for consistency
                    conveyor_belt_collider.getItems()[i].transform.position += constant_speed
                                                ?
                                                (paths[getClosestPathIndexToTransform(conveyor_belt_collider.getItems()[i]) - 1].position - conveyor_belt_collider.getItems()[i].transform.position).normalized * movement_speed
                                                :
                                                (paths[getClosestPathIndexToTransform(conveyor_belt_collider.getItems()[i]) - 1].position - conveyor_belt_collider.getItems()[i].transform.position) * movement_speed;

                }
            }


            // belt_renderer.material.SetTextureScale("_MainTex", new Vector2(-1, 1));
            belt_renderer.material.mainTextureScale = new Vector2(-1, 1);
        }

        // get the index of the transform object in the paths array that is closest to a particular item's position
        private int getClosestPathIndexToTransform(Item item)
        {
            int closest_index = 0;

            float closest_distance = float.MaxValue;

            for (int i = 0; i < paths.Length; i++)
            {
                if (closest_distance > Vector3.Distance(item.transform.position, paths[i].position))
                {
                    closest_index = i;
                    closest_distance = Vector3.Distance(item.transform.position, paths[i].position);
                }
            }

            return closest_index;
        }

        // Animate belt texture to show the direction the belt is moving
        private void animateBeltTexture()
        {
            if (conveyor_belt_scale_x <= 0)
            {
                conveyor_belt_scale_x = 1;
            }
            else
            {
                // the animation speed is tied to the movement speed at which the belt moves items and multiplied by 100, feel free to change the value
                // if you want
                conveyor_belt_scale_x -= Time.deltaTime * movement_speed * 100;
            }

            //belt_renderer.material.SetTextureOffset("_MainTex", new Vector2(conveyor_belt_scale_x, 0));


            belt_renderer.material.mainTextureOffset = new Vector2(conveyor_belt_scale_x, 0);
        }

    }


}