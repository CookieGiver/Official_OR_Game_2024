using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{
    public Transform door;
    public int goal;
    void Start()
    {
        door.transform.eulerAngles = new Vector3(
            0,
            door.transform.eulerAngles.y,
            door.transform.eulerAngles.z
        );
            }

    // Update is called once per frame
    void Update()
    {
        if (door.transform.eulerAngles[1] < goal)
        {
            transform.RotateAround(new Vector3 (-5.93f,1.9f,-5.12f), Vector3.up, 50 * Time.deltaTime);
        }

        
    }
}
