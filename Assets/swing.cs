using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{
    public Transform door;
    public int goal;
    public Vector3 pivot;
    public int start;

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
        Debug.Log("euler" + door.transform.eulerAngles[1]);
        Debug.Log("rotation" + door.rotation.y);
        if (door.transform.eulerAngles[1] > start + goal)
        {

            door.transform.Rotate(0, 0.3f, 0, Space.Self);
        }

        
    }
}
