using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OpcionesAnimacion : MonoBehaviour
{
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject image;
    void Start()
    {

    }

    void Update()
    {

    }


    public void BotonCrear()
    {
        menu.SetActive(false);
        gameObject.SetActive(true);
    }

    public void BotonCancelar()
    {
        menu.SetActive(true);
        gameObject.SetActive(false);

    }
}
