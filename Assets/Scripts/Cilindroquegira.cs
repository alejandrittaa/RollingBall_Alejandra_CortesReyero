using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cilindroquegira : MonoBehaviour
{
    [SerializeField] Vector3 direccion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direccion.normalized * 2 * Time.deltaTime);
    }
}
