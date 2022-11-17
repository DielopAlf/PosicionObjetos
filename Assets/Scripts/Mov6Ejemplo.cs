using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov6Ejemplo : MonoBehaviour

{

    public enum EstadosSelector
    { 
      EnEspera,
      SeleccionObjeto,
      ObjetoSeleccionado,
      Mover,
      Escalar,
      Rotar,
    //LOs estados que se necesiten//
    }
    [SerializeField]
    EstadosSelector estadoActual = EstadosSelector.EnEspera;







    public GameObject cube;
    Vector3 originalScale;

    void Update()
    {
        if ((Input.touchCount >=1 && Input.GetTouch(0).phase == TouchPhase.Ended) ||(Input.GetMouseButtonUp(0)))
        {

            if( cube == null)
            {

                SelectCube();
            }
            else
            {

                ReleaseCube();
            }
        }else if (cube != null)
        {

            Movecube();
        }

    }

    void Movecube()
    {
        Vector3 pos = Input.mousePosition;
        Ray rayo = Camera.main.ScreenPointToRay(pos);
        RaycastHit hitInfo;
        cube.SetActive(false);
        if (Physics.Raycast(rayo,out hitInfo) == true)
         {
            cube.transform.position = hitInfo.point + Vector3.up * cube.transform.localScale.y / 2;
         }
        cube.SetActive(true);
  
    }
    void ReleaseCube()
    {
        LeanTween.cancel(cube);

        LeanTween.scale(cube, originalScale, 0.75f).setEaseInBack();
        Debug.Log("Release");
        cube = null;
    }
    void SelectCube()
    {
        Debug.Log("Select");
        Vector3 pos = Input.mousePosition;
        if(Application.platform ==RuntimePlatform.Android)
        {
            pos = Input.GetTouch(0).position;
        }

        Ray rayo = Camera.main.ScreenPointToRay(pos);
        RaycastHit hitInfo;
        if(Physics.Raycast(rayo, out hitInfo) == true)
        {
            if (hitInfo.collider.tag.Equals("cube"))
            {
                cube = hitInfo.collider.gameObject;
                originalScale = cube.transform.localScale;
                LeanTween.scale(cube, cube.transform.localScale * 1.2f, 0.75f).setEaseInBounce().setLoopPingPong();
                    
                    
            }
               

                

        }
    }

       
}
