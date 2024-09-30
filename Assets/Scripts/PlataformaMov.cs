using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMov : MonoBehaviour
{

    [SerializeField] Vector3 direccion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direccion.normalized * 2 * Time.deltaTime);
    }
    
}
