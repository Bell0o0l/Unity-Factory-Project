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


    public class AcceptRejectComputerScreen : ComputerScreen
    {

        [SerializeField]
        private AcceptRejectMachine accept_reject_machine; // access to the accept reject machine

        [SerializeField]
        private TMPro.TMP_Text total_number_of_items_scanned_text; // totoal number of items scanned (accepted  + rejected)

        [SerializeField]
        private TMPro.TMP_Text number_of_items_rejected_text;

        [SerializeField]
        private TMPro.TMP_Text number_of_items_accepted_text;

        [SerializeField]
        private TMPro.TMP_Text acceptance_rate; // number of items accepted divided by total number of items scanned


        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();


        }

        // Update is called once per frame
        protected void Update()
        {

            total_number_of_items_scanned_text.text = (accept_reject_machine.accepted + accept_reject_machine.rejected).ToString();

            number_of_items_accepted_text.text = accept_reject_machine.accepted.ToString();
            number_of_items_rejected_text.text = accept_reject_machine.rejected.ToString();

            acceptance_rate.text = (getAcceptedRate() * 100).ToString("n1") + " %";

        }


        private float getAcceptedRate()
        {
            return (float)accept_reject_machine.accepted / (float)(accept_reject_machine.accepted + accept_reject_machine.rejected);
        }

        private float getRejectedRate()
        {
            return (float)accept_reject_machine.accepted / (float)(accept_reject_machine.accepted + accept_reject_machine.rejected);
        }


    }



}