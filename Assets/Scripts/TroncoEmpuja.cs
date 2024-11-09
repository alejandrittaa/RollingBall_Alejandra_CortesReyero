using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoEmpuja : MonoBehaviour
{
    public float pushForce = 100f; // Fuerza con la que empuja la bola
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que colisiona es la bola
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 pushDirection = collision.contacts[0].normal;
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            ballRb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}
