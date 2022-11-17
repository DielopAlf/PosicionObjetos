using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov6Ejemplo : MonoBehaviour

{




    public GameObject cube;

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
        if(Physics.Raycast(rayo))
        {


        }
    }

       
}
