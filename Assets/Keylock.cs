using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyLock : MonoBehaviour
{
    public string code;
    public Transform camera;
    public GameObject key;
    public Transform door;
    public bool active = false;
    public GameObject inputField;
    // Update is called once per frame
    void Update()
    {
        active = GetComponent<activate>().active;
        if (active)
        {

            Debug.Log(camera.gameObject.GetComponent<selector>().selected);
            if (camera.gameObject.GetComponent<selector>().selected == key)
            {
                door.gameObject.GetComponent<swing>().goal = 90;
                GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
            }
            GetComponent<activate>().active = false;
        }

    }


}

