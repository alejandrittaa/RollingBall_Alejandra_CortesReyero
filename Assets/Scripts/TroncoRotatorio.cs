using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoRotatorio : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocidad de rotación del tronco
    public float pushForce = 100f; // Fuerza con la que empuja la bola

    private void Update()
    {
        // Rota el tronco sobre su propio eje, como un ventilador
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.Self);  // Space.Self asegura que gire en su propio espacio local
    }

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
