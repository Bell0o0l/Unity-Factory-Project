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
    public abstract class ComputerScreen : MonoBehaviour
    {
        private RenderTexture render_texture; // for render texture. We want to show UI objects on mesh


        private Material screen_material; // for screen material

        [SerializeField]
        protected MeshRenderer screen_mesh; // access to the meshrenderer to screen object

        [SerializeField]
        protected Camera canvas_camera; // the camera that will be rendering the canvas details



        protected virtual void Start()
        {

            render_texture = new RenderTexture(2048, 2048, 16, RenderTextureFormat.ARGB32); // create render texture

            // If this is built in render pipeline, then use this line, 
            screen_material = new Material(Shader.Find("Standard"));

            //use this if you are running on a URP pipeline
            //screen_material = new Material(Shader.Find("Universal Render Pipeline/Lit"));

            //use this if you are running on a HDRP Pipeline
            //screen_material = new Material(Shader.Find("HDRP/Lit"));



            canvas_camera.targetTexture = render_texture;

            screen_material.mainTexture = render_texture;

            screen_material.EnableKeyword("_EMISSION");
            screen_material.SetTexture("_EmissionMap", render_texture);
            screen_material.SetColor("_EmissionColor", Color.white * 0.6f);

            screen_mesh.material = screen_material;

            // this random location is to make it improbable for 2 or more computer screens to clash in world space
            transform.localPosition = new Vector3(UnityEngine.Random.Range(-5000, 5000),
                                                  UnityEngine.Random.Range(-5000, 5000),
                                                  UnityEngine.Random.Range(-5000, 5000));
        }

    }
}