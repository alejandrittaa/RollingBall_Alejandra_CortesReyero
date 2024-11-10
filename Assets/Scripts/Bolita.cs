using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bolita : MonoBehaviour
{
    Rigidbody bolita;
    [SerializeField] Vector3 direccionF;
    [SerializeField] int fuerzaSalto;
    [SerializeField] int fuerzaMovimiento;
    [SerializeField] float distanciaRayo;
    int vidas = 3;
    //Vector3 posInicial;
    private bool enSueloResbaladizo = false;
    private Vector3 posicionInicial;
    public Transform checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        bolita = GetComponent<Rigidbody>(); 
        //para guardar la posición inicial en la que empieza la bola
        //posInicial = transform.position;

        //Checkpoint
        if (checkpoint != null)
        {
            posicionInicial = checkpoint.position;
        }
        else
        {
            posicionInicial = transform.position; // Usa la posición inicial del jugador si no hay un checkpoint asignado
        }

    }

    // Update is called once per frame
    void Update()
    {

        //SALTO CON EL ESPACIO
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //no hace falta poner ==true, ya que de esta manera ya está preguntando internamente, "si se cumple este método..."
            if(DetectaSuelo())
            {
                bolita.AddForce(direccionF * fuerzaSalto, ForceMode.Impulse);
            }
            
        }
        //MOVIMIENTO WASD Y FLECHAS
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(h, 0, v);
        float maxVelocidadResbalon = 5;
        float factorDesaceleracion = 0.9f;

        if (movimiento.magnitude > 0)
        {
            // Aplica fuerza en X y Z si hay movimiento
            bolita.AddForce(movimiento.normalized * fuerzaMovimiento, ForceMode.Force);
        }
        else
        {
            if (enSueloResbaladizo)
            {
                // En suelo resbaladizo, asegúrate de que la bola no se frene
                if (bolita.velocity.magnitude < maxVelocidadResbalon)
                {
                    // Aplica una pequeña aceleración constante en la dirección de la velocidad
                    Vector3 direccionDeMovimiento = bolita.velocity.normalized; // Dirección actual de la velocidad
                    bolita.velocity = new Vector3(direccionDeMovimiento.x * maxVelocidadResbalon, bolita.velocity.y, direccionDeMovimiento.z * maxVelocidadResbalon);
                    // Esto asegura que la bola no se frene y siga resbalando a una velocidad máxima
                }
            }
            else
            {
                // Si no estamos en suelo resbaladizo, aplicamos desaceleración en X y Z
                Vector3 velocidadActual = bolita.velocity;
                bolita.velocity = new Vector3(velocidadActual.x * factorDesaceleracion, velocidadActual.y, velocidadActual.z * factorDesaceleracion);
            }
        }
        //Checkpoint
        if (transform.position.y < -10) 
        {
            RegresarAlCheckpoint();
        }


    }

    //CHECKPOINT AL QUEDARSE SIN VIDAS
    /*private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("coleccionable"))
        {
            Destroy(other.gameObject);
        }else if (other.gameObject.CompareTag("trampa"))
        {
            Destroy(other.gameObject);
            if(vidas > 0)
            {
                vidas--;
                Debug.Log("Se te ha restado una vida");
            }else
            {
                Debug.Log("No te quedan vidas");
            }

        }else if(other.gameObject.CompareTag("checkpoint"))
        {
            transform.position = posInicial;
        }
    }*/

    private bool DetectaSuelo()
    {
        bool deteccion = Physics.Raycast(transform.position, Vector3.down, distanciaRayo);
        //el rayo solo se pinta en la ventana de edición, no en la de play/jugar
        Debug.DrawRay(transform.position, Vector3.down, Color.red, 2f);
        return deteccion;
    }

    //CHECKPOINT
    private void RegresarAlCheckpoint()
    {
        transform.position = posicionInicial;
        bolita.velocity = Vector3.zero; // Reinicia la velocidad de la bola para evitar efectos indeseados al reaparecer
    }

    public void ActualizarCheckpoint(Vector3 nuevaPosicion)
    {
        posicionInicial = nuevaPosicion;
    }

    //PARA MOVERSE SIGUIENDO LA TRAYECTORIA DE LAS PLATAFORMAS AL ESTAR ENCIMA Y PARA EL SUELO RESBALADIZO
    void OnCollisionEnter(Collision collision)
    {
        // Detecta si la bola aterriza sobre una plataforma móvil
        if (collision.gameObject.CompareTag("PlataformaMovil"))
        {
            // Establece la plataforma como el parent de la bola
            transform.parent = collision.transform;
        }

        // Detecta si la bola aterriza sobre un suelo resbaladizo
        if (collision.gameObject.CompareTag("SueloResbaladizo"))
        {
            enSueloResbaladizo = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Detecta cuando la bola deja la plataforma
        if (collision.gameObject.CompareTag("PlataformaMovil"))
        {
            // Quita la plataforma como el parent de la bola
            transform.parent = null;
        }

        // Detecta cuando la bola deja el suelo resbaladizo
        if (collision.gameObject.CompareTag("SueloResbaladizo"))
        {
            enSueloResbaladizo = false;
        }
    }

}
