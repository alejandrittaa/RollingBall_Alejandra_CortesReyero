using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolita : MonoBehaviour
{
    Rigidbody bolita;
    [SerializeField] Vector3 direccionF;
    [SerializeField] int fuerza;
    [SerializeField] Vector3 direccionM;
    [SerializeField] int fuerzaM;
    //[SerializeField] Vectro3 direccionS;
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
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            bolita.AddForce(direccionM * fuerzaM, ForceMode.Force);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            bolita.AddForce(-(direccionM) * fuerzaM, ForceMode.Force);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            bolita.AddForce(direccionM * fuerzaM, ForceMode.Force);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            bolita.AddForce(direccionM * fuerzaM, ForceMode.Force);
        }

    }
}
