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
    public class OutputCollectionScreen : ComputerScreen
    {

        [SerializeField]
        private OutputCollection output_collection;


        [SerializeField]
        private TMPro.TMP_Text items_collected_text;


        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();

        }

        // Update is called once per frame
        protected void Update()
        {
            items_collected_text.text = output_collection.items_collected.ToString();

        }
    }


}