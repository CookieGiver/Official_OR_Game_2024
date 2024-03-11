using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform laserOrigin;
    LineRenderer laser;
    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("hello");
        laser.SetPosition(0, laserOrigin.localPosition);
        Vector3 rayOrigin = laserOrigin.localPosition;
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, laserOrigin.forward, out hit, 100f))
        {
            laser.SetPosition(1, hit.point);
        }
        else
        {
            laser.SetPosition(1, rayOrigin + laserOrigin.forward * 100f);
        }
    }
}
