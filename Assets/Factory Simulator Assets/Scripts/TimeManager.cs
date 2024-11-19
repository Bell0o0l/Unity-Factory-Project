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
using System;




namespace FactorySimulator
{
    public class TimeManager : MonoBehaviour
    {

        private static TimeManager instance;

        // for singleton
        public static TimeManager Instance
        {
            get
            {
                return instance;
            }
        }


        public DateTime started_time // time the program started running in datetime format
        {
            get;
            private set;
        }

        public DateTime current_time // current time in datetime format
        {
            get;
            private set;
        }


        // Start is called before the first frame update
        void Start()
        {
            if (instance == null)
            {
                instance = this;
            }

            started_time = DateTime.Now; // get datetime at start
        }

        // Update is called once per frame
        void Update()
        {

            current_time = DateTime.Now;
        }
    }


}