using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetController : MonoBehaviour
{
    void Update()
    {
        GetComponent<Transform>().localPosition  = Vector3.zero;
    }
}
