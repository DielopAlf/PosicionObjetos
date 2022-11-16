using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mov5Definitivo : MonoBehaviour
{

    [SerializeField]
    private InputAction mouseClick;
    [SerializeField]
    private float mouseDragPhysicsSpeed = 10;
    [SerializeField]
    private float mouseDragSpeed = .1f;

    private Camera mainCamera;
    private Vector3 velocity = Vector3.zero;
    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
    private void Awake()
    {
        mainCamera= Camera.main;
    }


    private void OnEnable()
    {
        mouseClick.Enable();

        mouseClick.performed += MousePressed;
    
    }

     private void OnDisable()
    {
        mouseClick.performed -= MousePressed;
        mouseClick.Disable();
    }
    private void MousePressed(InputAction.CallbackContext context)
    { 
        Ray rayo = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hitInfo;
        if (Physics.Raycast(rayo, out hitInfo))
        { 
            
            {
                if (hitInfo.collider != null && (hitInfo.collider.gameObject.CompareTag("Movible") ||  hitInfo.collider.
                    gameObject.layer ==LayerMask.NameToLayer("Movible"))) 
                {
                    StartCoroutine(DragUpdate(hitInfo.collider.gameObject));
                }
                
            }

        }
    }
    private IEnumerator DragUpdate(GameObject clickedObject)
    {
        float initialDistance = Vector3.Distance(clickedObject.transform.position, mainCamera.transform.position);
        clickedObject.TryGetComponent<Rigidbody>(out var rb);
        while (mouseClick.ReadValue<float>() !=0)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if(rb !=null)
            {
                Vector3 direction = ray.GetPoint(initialDistance) - clickedObject.transform.position;
                rb.velocity = direction * mouseDragPhysicsSpeed;
                yield return new WaitForFixedUpdate();
            }
            else
            {

                clickedObject.transform.position =Vector3.SmoothDamp(clickedObject.transform.position, ray.
                    GetPoint(initialDistance), ref velocity, mouseDragSpeed);
                yield return null;
            }
                
        }  
    
    }
}
