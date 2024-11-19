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

    // this class basically allows the in game camera to function like the scene view camera

    public class CameraController : MonoBehaviour
    {

        private float pitch_rotation = 0;
        private float yaw_rotation = 0;


        [SerializeField]
        [Range(1, 5)]
        private float turn_speed = 2; // speed for yaw and pitch rotation

        [SerializeField]
        [Range(1, 5)]
        private float move_speed = 1; // speed for up, down, left, right movement 

        [SerializeField]
        [Range(0.4f, 1.5f)]
        private float zoom_speed = 1; // speed for forward and backward movement


        // Update is called once per frame
        void Update()
        {

            if (Input.GetMouseButton(1)) // if mouse right button is down, change pitch and yaw rotation, depending on the mouse movement
            {
                pitch_rotation -= Input.GetAxis("Mouse Y") * turn_speed;
                yaw_rotation += Input.GetAxis("Mouse X") * turn_speed;
            }

            if (Input.GetMouseButton(2)) // if mouse middle scrollwheel button is down, allow up, down, left, right movement
            {
                transform.position += (-transform.right * Input.GetAxis("Mouse X") * move_speed) + (-transform.up * Input.GetAxis("Mouse Y") * move_speed);
            }

            // roll the mouse scroll wheel to move camera forwards and backwards
            transform.position += transform.forward * Input.mouseScrollDelta.y * zoom_speed;


            // update rotation based on pitch and yaw values
            transform.rotation = Quaternion.Euler(pitch_rotation, yaw_rotation, 0);

        }

    }


}

