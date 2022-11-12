using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov2 : MonoBehaviour
{

    private GameObject selectedObject;


    private void update() {
        
           if (Input.GetMouseButtonDown(0)) {
               if(selectedObject == null){
               RaycastHit hit=CastRay();

               if(hit.collider != null){
                  if(!hit.collider.CompareTag("ObjetoMover")){
                      return;
                  }
                  selectedObject = hit.collider.gameObject; 
                  Cursor.visible = false;
               }

               
              } else {

              }
           }
    
           if(selectedObject != null){
              Vector3 position = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
              Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
              selectedObject.transform.position = new Vector3(worldPosition.x,.25f, worldPosition.z);


           }


    }

    private RaycastHit CastRay(){
        Vector3 screenMousePosFar = new Vector3(
          Input.mousePosition.x,
          Input.mousePosition.y,
          Camera.main.farClipPlane);
          
         Vector3 screenMousePosNear = new Vector3(
          Input.mousePosition.x,
          Input.mousePosition.y,
          Camera.main.nearClipPlane);
         
         Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
         Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
         RaycastHit hit;
         Physics.Raycast(worldMousePosNear,worldMousePosFar = worldMousePosNear, out hit);

         return hit;
    }
}
