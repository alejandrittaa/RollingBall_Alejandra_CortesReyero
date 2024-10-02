using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cilindroquegira : MonoBehaviour
{
    [SerializeField] Vector3 direccionR;
    [SerializeField] Vector3 direccionM;
    int velocidadR = 90;
    float timer = 0;
    int velocidadM = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direccionM * velocidadR * Time.deltaTime, Space.World);
        transform.Translate(direccionM.normalized * velocidadM * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= 3)
        {
            direccionM = -direccionM;
            timer = 0;
        }
    }
}
