using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    private static Musica unica;

    void Awake()
    {
        // PARA ASEGURARNOS DE QUE SE ESUCHA LA CANCION SIN INTERRUPCIONES AUNQUE CAMBIEMOS DE ESCENA.
        if (unica != null && unica != this)
        {
            Destroy(gameObject);
            return;
        }

        
        unica = this;
        DontDestroyOnLoad(gameObject);
    }
}
