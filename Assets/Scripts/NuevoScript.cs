using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoScript : MonoBehaviour
{

    //


    public enum EstadosSelector
    {
        EnEspera,
        SeleccionObjetoMover,
        SeleccionObjetoRotar,
        ObjetoSeleccionado,
        Mover,
        Escalar,
        Soltar,
        Rotar,
        //LOs estados que se necesiten//
    }
    [SerializeField]
    EstadosSelector estadoActual = EstadosSelector.EnEspera;
    public GameObject objetoseleccionado;


    void Update()
    {
        switch (estadoActual)
        {


            case EstadosSelector.EnEspera:
                estadoActual = EstadosSelector.SeleccionObjetoMover;
                break;
            case EstadosSelector.SeleccionObjetoMover:
                SeleccionObjeto();
                break;
            case EstadosSelector.Mover:
                MoverObjeto();
                break;
            case EstadosSelector.Soltar:
                SoltarObjeto();
                break;

        }

    }
    void SeleccionObjeto()
    {

        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                GameObject objectHit = hit.transform.gameObject;
                if (objectHit.CompareTag("Movible"))
                {
                    objetoseleccionado = objectHit;

                    if (estadoActual == EstadosSelector.SeleccionObjetoMover)
                        estadoActual = EstadosSelector.Mover;

                }


            }

        }

    }
    void MoverObjeto()

    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        objetoseleccionado.SetActive(false);

        if (Physics.Raycast(ray, out hit))
        {
            objetoseleccionado.transform.position = hit.point + ((Vector3.up * objetoseleccionado.transform.localScale.y)/2);
        }


        objetoseleccionado.SetActive(true);






    }

    void SoltarObjeto()
    {
        objetoseleccionado = null;


    }
    
        





}


            
    

        
        
   
        
       
    
        
        




    

     
   

