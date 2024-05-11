using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slide : MonoBehaviour
{

    public Transform other;
    public float goal;
    private float count = 0;
    void Update()
    {
        if (count < goal)
        {
            transform.position = transform.position + new Vector3(0.3f * Time.deltaTime, 0, 0);
            other.position = other.position + new Vector3(0.3f * Time.deltaTime, 0, 0);
            count += 0.3f * Time.deltaTime;
        }
    }
}
