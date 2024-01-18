using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

    void LateUpdate()
    {
        Vector3 direction  = Camera.main.transform.forward;
        this.transform.forward = direction;
    }
}
