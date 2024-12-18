using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolasRodantes : MonoBehaviour
{
    float timer = 0;
    int velocidad = 3;
    [SerializeField] Vector3 direccion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(direccion.normalized * velocidad * Time.deltaTime);
        timer += Time.deltaTime;

        if (timer >= 2)
        {
            direccion = -direccion;
            timer = 0;
        }

    }
}
