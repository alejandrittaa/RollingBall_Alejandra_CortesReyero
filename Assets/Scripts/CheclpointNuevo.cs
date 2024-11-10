using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheclpointNuevo : MonoBehaviour
{
    public Bolita bolaController; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bolaController.ActualizarCheckpoint(transform.position);
        }
    }
}
