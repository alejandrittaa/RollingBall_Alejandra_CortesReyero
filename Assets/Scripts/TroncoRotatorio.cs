using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoRotatorio : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocidad de rotación del tronco
    

    private void Update()
    {
        // Rota el tronco sobre su propio eje, como un ventilador
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.Self);  // Space.Self asegura que gire en su propio espacio local
    }
}
