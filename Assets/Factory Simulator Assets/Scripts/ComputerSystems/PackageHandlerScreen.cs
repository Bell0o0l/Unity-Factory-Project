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
    public class PackageHandlerScreen : ComputerScreen
    {

        [SerializeField]
        private TMPro.TMP_Text number_of_items_text; // to show the number of items 


        [SerializeField]
        private PackageHandler package_handler; // access to the package handler

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        protected void Update()
        {
            number_of_items_text.text = package_handler.current_items.ToString();
        }
    }

}
