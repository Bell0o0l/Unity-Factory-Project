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
using UnityEditor;


public class CreateFactoryMachineEditorScript
{

    [MenuItem("GameObject/Factory Simulator/Sim_Factory", false, -1)]
    private static void createSimFactory()
    {
        createPrefabResource("Sim_Factory");

    }

    [MenuItem("GameObject/Factory Simulator/Sim_accept_reject_machine", false, -1)]
    private static void createSimAcceptRejectMachine()
    {
        createPrefabResource("Sim_accept_reject_machine");

    }
    
    [MenuItem("GameObject/Factory Simulator/Sim_conveyor_belt 1", false, -1)]
    private static void createConveyorBelt1()
    {
        createPrefabResource("Sim_conveyor_belt");

    }

    [MenuItem("GameObject/Factory Simulator/Sim_conveyor_belt 2", false, -1)]
    private static void createConveyorBelt2()
    {
        createPrefabResource("Sim_conveyor_belt2");

    }

    [MenuItem("GameObject/Factory Simulator/Sim_conveyor_belt 3", false, -1)]
    private static void createConveyorBelt3()
    {
        createPrefabResource("Sim_conveyor_belt3");

    }

    [MenuItem("GameObject/Factory Simulator/Sim_conveyor_belt 4", false, -1)]
    private static void createConveyorBelt4()
    {
        createPrefabResource("Sim_conveyor_belt4");

    }


    [MenuItem("GameObject/Factory Simulator/Sim_in_out_machine", false, -1)]
    private static void createSimInOutMachine()
    {
        createPrefabResource("Sim_in_out_machine");

    }

    [MenuItem("GameObject/Factory Simulator/Sim_in_out_machine 2", false, -1)]
    private static void createSimInOutMachine2()
    {
        createPrefabResource("Sim_in_out_machine 2");

    }


    [MenuItem("GameObject/Factory Simulator/Sim_Item_Maker", false, -1)]
    private static void createSimItemMaker()
    {
        createPrefabResource("Sim_Item_Maker");

    }


    [MenuItem("GameObject/Factory Simulator/Sim_Output_Collection", false, -1)]
    private static void createSimOutputCollection()
    {
        createPrefabResource("Sim_Output_Collection");

    }

    [MenuItem("GameObject/Factory Simulator/Sim_Package_Handler", false, -1)]
    private static void createSimPackageHandler()
    {
        createPrefabResource("Sim_Package_Handler");

    }

    [MenuItem("GameObject/Factory Simulator/Sim_pusher_machine", false, -1)]
    private static void createSimPusherMachine()
    {
        createPrefabResource("Sim_pusher_machine");

    }

    [MenuItem("GameObject/Factory Simulator/Sim_Rejected_Items_Container", false, -1)]
    private static void createSimRejectedItemsContainer()
    {
        createPrefabResource("Sim_Rejected_Items_Container");

    }


    [MenuItem("GameObject/Factory Simulator/Sim_Time_Manager_Screen", false, -1)]
    private static void createSimTimeManagerScreen()
    {
        createPrefabResource("Sim_Time_Manager_Screen");

    }


    [MenuItem("GameObject/Factory Simulator/Sim_Camera", false, -1)]
    private static void createSimCamera()
    {
        createPrefabResource("Sim_Camera");

    }


    

    private static void createPrefabResource(string object_name)
    {

        Object factory_object = Resources.Load("prefabs/" + object_name); // find prefab in resources

        GameObject game_object = (GameObject)GameObject.Instantiate(factory_object, Vector3.zero, Quaternion.identity); // instantiate object

        game_object.name = object_name; // name object



        GameObject selected_object = Selection.activeGameObject; // current selected game object


        if (selected_object) // if selected object is not null
        {

            game_object.transform.SetParent(selected_object.transform, false);

        }
        

        Selection.activeGameObject = game_object;
    }

   
}