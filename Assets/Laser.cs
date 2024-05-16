using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform laserOrigin;
    LineRenderer laser;
    public int reflections = 1;

    private Vector3 rayOrigin;
    private RaycastHit hit;
    private Vector3 direction;

    public float maxLength = 100f;


    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("hello");

        laser.positionCount = 1;
        laser.SetPosition(0, laserOrigin.position);
        direction = laserOrigin.forward;
        rayOrigin = laserOrigin.position;

        for (int i = 0; i < reflections; i++)
        {
            if (Physics.Raycast(rayOrigin, direction, out hit, 100f, Physics.AllLayers, QueryTriggerInteraction.Ignore))
            {
                if (hit.transform.gameObject.GetComponent<Mirror>() != null)
                {
                    laser.positionCount++;
                    laser.SetPosition(laser.positionCount - 1, hit.point);
                    rayOrigin = hit.point;
                    direction = Vector3.Reflect(direction, hit.normal);
                }
                else
                {
                    laser.positionCount++;
                    laser.SetPosition(laser.positionCount - 1, hit.point);
                    break;
                }
            }

            else
            {
                laser.positionCount++;
                laser.SetPosition(laser.positionCount - 1, rayOrigin + laserOrigin.forward * 100f);
                break;
            }
        }
        
        

    }
    private void FixedUpdate()
    {
        //laserOrigin.Rotate(new Vector3(5, 0, 0)*Time.deltaTime);
        //Debug.Log(laserOrigin.position);
    }
}
