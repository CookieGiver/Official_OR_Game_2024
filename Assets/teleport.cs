using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public GameObject player;
    public Vector3 newloc;
    private bool active;
    void Update()
    {
        active = GetComponent<activate>().active;
        if (active)
        {
            player.transform.position = newloc;
            GetComponent<activate>().active = false;
            
        }
    }
}
