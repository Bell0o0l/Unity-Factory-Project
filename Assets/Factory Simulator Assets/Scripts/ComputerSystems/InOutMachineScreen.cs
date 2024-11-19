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
    public class InOutMachineScreen : ComputerScreen
    {

        [SerializeField]
        private InOutMachine in_out_machine;



        [SerializeField]
        private TMPro.TMP_Text total_items_processed;


        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();

        }

        // Update is called once per frame
        protected void Update()
        {
            total_items_processed.text = in_out_machine.total_items_processed.ToString();


        }
    }

}