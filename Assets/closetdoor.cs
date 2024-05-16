using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closetdoor : MonoBehaviour
{

    public bool active;
    public GameObject door;
    void Update()
    {
        active = GetComponent<activate>().active;
        if (active)
        {
            if (door.transform.eulerAngles[1] > 1)
            {

                door.transform.Rotate(0, -0.3f, 0, Space.Self);
            }
        }
     }
}
