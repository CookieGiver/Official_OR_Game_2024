using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public GameObject ladder;
    public Vector3 newpos;
    public GameObject roof;
    private bool active;
    // Update is called once per frame
    void Update()
    {
        active = GetComponent<activate>().active;
        if (active)
        {
            ladder.transform.position = ladder.transform.position + newpos;
            GetComponent<activate>().active = false;
        }
    }
}
