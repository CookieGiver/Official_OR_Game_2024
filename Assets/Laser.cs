using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public GameObject ball;
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
            float angle = Mathf.Acos(Vector3.Dot(hit.normal, laserOrigin.forward)) * 180/Mathf.PI;
            Debug.Log(angle);
            
        }
        else
        {
            laser.SetPosition(1, rayOrigin + laserOrigin.forward * 100f);
        }

    }
    private void FixedUpdate()
    {
        laserOrigin.Rotate(new Vector3(5, 0, 0)*Time.deltaTime);
        Debug.Log(laserOrigin.position);
    }
}
