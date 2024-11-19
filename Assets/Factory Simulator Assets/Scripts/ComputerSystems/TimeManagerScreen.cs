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
    public class TimeManagerScreen : ComputerScreen
    {

        [SerializeField]
        private TMPro.TMP_Text time_difference_text; // to show the time ellapsed since program started

        [SerializeField]
        private TMPro.TMP_Text processing_started_at_text; // when the program started

        [SerializeField]
        private TMPro.TMP_Text current_time_text; // current time


        protected override void Start()
        {
            base.Start();
        }


        protected void Update()
        {
            // to format hours, minutes and seconds in 00:00:00
            time_difference_text.text = TimeManager.Instance.current_time.Subtract(TimeManager.Instance.started_time).Hours.ToString("D2")
                                        + ":" +
                                        TimeManager.Instance.current_time.Subtract(TimeManager.Instance.started_time).Minutes.ToString("D2")
                                        + ":" +
                                        TimeManager.Instance.current_time.Subtract(TimeManager.Instance.started_time).Seconds.ToString("D2");


            processing_started_at_text.text = TimeManager.Instance.started_time.ToString();

            current_time_text.text = TimeManager.Instance.current_time.ToString();


        }


    }


}