using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bougerPeinture : MonoBehaviour
{
    public float vitesse = 1f;
    void Update()
    {
        float h = vitesse * Input.GetAxis("Mouse X");
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0, h, 0);
        }
    }
}
