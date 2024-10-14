using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CambiaCamaras : MonoBehaviour
{
    [SerializeField] private GameObject cam1;
    [SerializeField] private GameObject cam2;

    //Cuando el jugador atraviese el cambiacamaras, cambiamos de cámara.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (cam1.activeSelf)
            {
                cam1.SetActive(false);
                cam2.SetActive(true);
            }else
            {
                cam1.SetActive(true);
                cam2.SetActive(false);
            }
            
        }
    }
}
