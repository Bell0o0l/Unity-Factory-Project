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
using UnityEngine.UI;



namespace FactorySimulator
{
    public class ItemMakerComputerScreen : ComputerScreen
    {


        [SerializeField]
        private ItemMaker item_maker;


        [SerializeField]
        private TMPro.TMP_Text output_frequency_text;

        [SerializeField]
        private TMPro.TMP_Text batch_output_text;


        [SerializeField]
        private TMPro.TMP_Text batch_delay_text;


        [SerializeField]
        private TMPro.TMP_Text quality_rate_text;


        [SerializeField]
        private TMPro.TMP_Text total_items_produced_text;


        [SerializeField]
        private TMPro.TMP_Text off_screen_text;

        [SerializeField]
        private GameObject on_screen;

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();


        }

        // Update is called once per frame
        protected void Update()
        {
            if(item_maker.is_machine_on)
            {
                on_screen.SetActive(true);

                output_frequency_text.text = item_maker.output_frequency.ToString("n1") + " seconds";

                batch_output_text.text = item_maker.batch_output.ToString() + " Items";

                batch_delay_text.text = item_maker.batch_delay.ToString("n1") + " seconds";

                quality_rate_text.text = ((int)(item_maker.quality_rate * 100)).ToString() + " %";

                total_items_produced_text.text = item_maker.total_items_produced.ToString() + " Items";

                off_screen_text.gameObject.SetActive(false);
            }
            else
            {
                on_screen.SetActive(false);
                off_screen_text.gameObject.SetActive(true);

                off_screen_text.text = " Tap screen to switch on this machine";
            }
            
        }
    }


}