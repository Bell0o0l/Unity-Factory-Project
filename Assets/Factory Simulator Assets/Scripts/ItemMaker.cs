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
    public class ItemMaker : MonoBehaviour
    {

        [SerializeField]
        private Item item_prefab; // prefab the item to spawn

        [SerializeField]
        [Range(0.1f, 10)]
        public float output_frequency = 0.5f;// time (in seconds) before spawning another item in the batch


        [SerializeField]
        [Range(1f, 10)]
        public int batch_output = 10; // number of items we will spawn in a given batch


        private int item_in_batch; // this allows us to keep track of the current items we have spawned in a batch

        [SerializeField]
        [Range(0.1f, 10)]
        public float batch_delay = 2; // delay after every batch


        [SerializeField]
        [Range(0.01f, 1)]
        public float quality_rate = 0.6f; // the chances we will produce a faulty item. Set value to 1 if you want no item to be faulty

        [SerializeField]
        private Transform spawn_location; // location in which we will spawn item


        private float spawn_counter; // to keep track of time to spawn the next item

        private float batch_counter; // to keep track of time to begin spawnning items for the next batch


        public int total_items_produced // total items that we have produced
        {
            get;
            private set;
        }


        public bool is_machine_on; // machine can only work and produce when on
  



        // 3d buttons to increase and decrease different values

        [SerializeField]
        private Button3D power_button;


        [SerializeField]
        private Button3D increase_output_frequency_button;

        [SerializeField]
        private Button3D decrease_output_frequency_button;



        [SerializeField]
        private Button3D increase_batch_output_button;

        [SerializeField]
        private Button3D decrease_batch_output_button;



        [SerializeField]
        private Button3D increase_batch_delay_button;

        [SerializeField]
        private Button3D decrease_batch_delay_button;



        [SerializeField]
        private Button3D increase_quality_output_button;

        [SerializeField]
        private Button3D decrease_quality_output_button;






        private void Start()
        {

            power_button.setClickAction(() => { is_machine_on = !is_machine_on; });

            increase_output_frequency_button.setClickAction(() => { output_frequency += 0.1f; });
            decrease_output_frequency_button.setClickAction(() => { output_frequency -= 0.1f; });


            increase_batch_delay_button.setClickAction(() => { batch_delay += 0.1f; });
            decrease_batch_delay_button.setClickAction(() => { batch_delay -= 0.1f; });


            increase_batch_output_button.setClickAction(() => { batch_output += 1; });
            decrease_batch_output_button.setClickAction(() => { batch_output -= 1; });


            increase_quality_output_button.setClickAction(() => { quality_rate += 0.01f; });
            decrease_quality_output_button.setClickAction(() => { quality_rate -= 0.01f; });

        }

        void Update()
        {
            if(is_machine_on)
            {
                updateMachineBehaviour();
            }

            
        }

        private void updateMachineBehaviour()
        {
            if (item_in_batch < batch_output)
            {
                produceItems();
            }
            else
            {
                produceBatch();
            }
        }



        private void produceBatch()
        {
            if (batch_counter < batch_delay)
            {
                batch_counter += Time.deltaTime;
            }
            else
            {
                item_in_batch = 0;

                batch_counter = 0;
            }
        }
        private void produceItems()
        {
            if (spawn_counter < output_frequency)
            {
                spawn_counter += Time.deltaTime;
            }
            else
            {

                Item item_to_spawn = Instantiate(item_prefab, spawn_location.position, Quaternion.identity);


                item_in_batch += 1;


                item_to_spawn.faulty = quality_rate < UnityEngine.Random.value;

                total_items_produced += 1;

                spawn_counter = 0;
            }
        }
    }


}