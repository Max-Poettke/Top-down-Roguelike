using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair_Behaviour : MonoBehaviour
{

    private Vector3 position;

    // Update is called once per frame
    void Update()
    {
        position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;
        transform.position = position;
    }
}
