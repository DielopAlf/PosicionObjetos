using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;






/* En el update comprobamos el estado y si esta en seleccionar objeto para mover rotar o escalar ejecutamos la funcion selecion objetos.
 * En selección objetos comprobamos si hacemos click y si le damos con un raycast a un objeto que tenga el tag de movible. 
 * En caso de que si guardamos ese objeto en la variable objetos seleccionados y cambiamos el estado a mover, escalar o rotar en base que estuvieramos en el estado de selec objeto mover escala o rotar.
 * En el update si estamos en alguno d elos 3 estados ejecutamos la funcion de cada uno.
 *
 *
 * */
public class NuevoScript : MonoBehaviour
{

    public Button mover;
    public Button rotar;
    public Button escalar;
    public Button crear;
    public GameObject prefabcubo;
    public GameObject prefabCilindro;
    public GameObject prefabesfera;
    public enum EstadosSelector
    {
        EnEspera,
        SeleccionObjetoMover,
        SeleccionObjetoRotar,
        SeleccionObjetoEscalar,
        EsperaTrasCreacion,
        
        ObjetoSeleccionado,
        Mover,
        Escalar,
        Soltar,
        Rotar,
        Crear,

        //LOs estados que se necesiten//
    }
    [SerializeField]
    EstadosSelector estadoActual = EstadosSelector.EnEspera;
    public GameObject objetoseleccionado;


    void Update()
    {
        switch (estadoActual)
        {

          
             
            // case EstadosSelector.EnEspera:
            //   estadoActual = EstadosSelector.SeleccionObjetoMover;
            //   estadoActual = EstadosSelector.SeleccionObjetoMover;
            //   break;
            case EstadosSelector.SeleccionObjetoMover:
                SeleccionObjeto();
                break;
            case EstadosSelector.Mover:
                MoverObjeto();
                break;
            case EstadosSelector.SeleccionObjetoRotar:
                SeleccionObjeto();
               break;

            case EstadosSelector.Rotar:
                rotarObjeto();
                break;
            case EstadosSelector.SeleccionObjetoEscalar:
                SeleccionObjeto();
                break;
            case EstadosSelector.Escalar:
                escalarObjeto();
                break;
            case EstadosSelector.EsperaTrasCreacion:
                estadoActual = EstadosSelector.Mover;
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
                    
                    
                    //objetoseleccionadocambiarestado (añadir is 



                    objetoseleccionado = objectHit;

                    if (estadoActual == EstadosSelector.SeleccionObjetoMover)
                    {

                        estadoActual = EstadosSelector.Mover;

                    }
                     else if (estadoActual == EstadosSelector.SeleccionObjetoRotar)
                    {

                        estadoActual= EstadosSelector.Rotar;
                        
                    }
                    else if (estadoActual == EstadosSelector.SeleccionObjetoEscalar)
                    {


                        estadoActual= EstadosSelector.Escalar;
                        //Debug.Log("prueba");

                    }
                    else if (estadoActual == EstadosSelector.EsperaTrasCreacion)
                    {


                        estadoActual = EstadosSelector.Crear;
                        //Debug.Log("prueba");

                    }
                    
                }   


            }

        }

    }
    //movemos el objeto al punto donde este el raton.
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
        if (Input.GetMouseButtonUp(0))
        {
            estadoActual = EstadosSelector.EnEspera;
            objetoseleccionado = null;

        }






    }
    void rotarObjeto()

    {
        

        if (Input.GetAxis("Mouse ScrollWheel")>0) 

            

        {

            objetoseleccionado.transform.Rotate(Vector3.down*10f,Space.Self);

        }else if(Input.GetAxis("Mouse ScrollWheel")<0)
        {

            objetoseleccionado.transform.Rotate(Vector3.up*10f, Space.Self);

        }





        if (Input.GetMouseButtonUp(0))
        {
            estadoActual = EstadosSelector.EnEspera;
            objetoseleccionado = null;

        }




    }
    //si movemos la rueda del raton escalamos el objeto 

    void escalarObjeto()
    {
        if (Input.GetAxis("Mouse ScrollWheel")>0)
        {

            objetoseleccionado.transform.localScale = objetoseleccionado.transform.localScale+new Vector3(1f, 1f, 1f);

        }
        else if (Input.GetAxis("Mouse ScrollWheel")<0)
        {

            objetoseleccionado.transform.localScale = objetoseleccionado.transform.localScale-new Vector3(1f, 1f, 1f);

        }





        if (Input.GetMouseButtonUp(0))
        {
            estadoActual = EstadosSelector.EnEspera;
            objetoseleccionado = null;

        }




    }
    public void CrearObjeto(GameObject elementoACrear)
    {
        GameObject nuevoObjeto = Instantiate(elementoACrear, Vector3.zero, Quaternion.identity);
        objetoseleccionado.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        //Color prueba = new Color();
        //prueba.b Random.Range(0f,125f);
        //prueba.g Random.Range(0f,125f);
        //prueba.c Random.Range(0f,125f);
        //prueba.c Random.Range(0f,125f);
        //prueba.a = 1f;
        //objetoseleccionado.GetComponent<MeshRenderer>().material.color = prueba;

        estadoActual = EstadosSelector.EsperaTrasCreacion;
        
    }




   

    public void seleccionarmover()
       
    {
        estadoActual = EstadosSelector.SeleccionObjetoMover;
    }

    public void seleccionarRotar()
    {
        
        estadoActual = EstadosSelector.SeleccionObjetoRotar;
    }

    public void seleccionarEscalar()
    {
        estadoActual=EstadosSelector.SeleccionObjetoEscalar;

    }
    public void Seleccionarcrear()
    {

      //  estadoActual = EstadosSelector.SeleccionObjetoCrear;

    }
   
}


            
    

        
        
   
        
       
    
        
        




    

     
   

