using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selector : MonoBehaviour
{
    public LayerMask layermask;
    // Start is called before the first frame update
    public GameObject target;
    public GameObject prevhit;
    public Color prevcolor = Color.red;
    void Update()
    {
        if (prevhit != target)
        {

            prevhit.GetComponent<Renderer>().material.color = prevcolor;
        }

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit, 10, layermask))
        {
            Debug.Log("There is something in front of the object!");
            prevhit = target;
            target = hit.collider.gameObject;

            if (prevhit != target)
            {

                prevcolor = target.GetComponent<Renderer>().material.color;
            }
            target.GetComponent<Renderer>().material.color = Color.white;
        }
        else
        {
            target = GameObject.Find("dummy");
        }
            


    }
}
