using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolita : MonoBehaviour
{
    Rigidbody bolita;
    [SerializeField] Vector3 direccionF;
    [SerializeField] Vector3 direccionM;
    [SerializeField] int fuerza;

    // Start is called before the first frame update
    void Start()
    {
        bolita = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //SALTO CON EL ESPACIO
        if(Input.GetKeyDown(KeyCode.Space))
        {
            bolita.AddForce(direccionF * fuerza, ForceMode.Impulse);
        }
        //MOVIMIENTO WASD Y FLECHAS
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bolita.AddForce(direccionM * fuerza, ForceMode.Force);


    }
}
