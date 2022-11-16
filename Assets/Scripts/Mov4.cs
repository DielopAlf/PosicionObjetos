using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov4 : MonoBehaviour
{
    bool isDrag;
    Transform focus;
    Camera cam;
    Vector3 screenPos;
    Vector3 offset;
    RaycastHit hitinfo;
    Ray rayo;

    private void Start()
    {
        isDrag=false;
        cam =Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            rayo= cam.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(rayo.origin, rayo.direction, out hitinfo))
         {
          focus =hitinfo.collider.transform;
          print("click=" +focus.name);


          screenPos =cam.WorldToScreenPoint(focus.position);
          offset =focus.position -cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,screenPos.z));
          isDrag =true;
         }


        }else if (Input.GetMouseButtonUp(0) && isDrag ==true)
        {
            isDrag=false;
        }
        else if(isDrag ==true)
        {
        //var
        Vector3 currentScreenPos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,screenPos.z);
        Vector3 currentPos = cam.ScreenToWorldPoint(currentScreenPos) + offset;
        
        focus.position= currentPos; 
        }
    }
}
