using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class notebook : MonoBehaviour
{
    public bool active;
    public Image rt;
    public Transform trans;
    public Canvas canvas;
    public Canvas inv;
    private bool close = false;
    public BoxCollider col;
    public GameObject camera;
    // Update is called once per frame
    void Update()
    {
        active = GetComponent<activate>().active;
        if (active)
        {
            col.enabled = false;
            GameObject button = GameObject.Find("Notebook button");
            Image buttonimg = button.GetComponent<Image>();
            buttonimg.sprite = rt.sprite;
            trans.position = new Vector3(1000, 0, 0);
        }


        if (close)
        {

            camera.GetComponent<Inventory>().open = true;
            canvas.enabled = false;
            inv.enabled = true;
            close = false;
            
        }
    }

    public void opennote()
    {
        if (active)
        {

            camera.GetComponent<Inventory>().open = false;
            canvas.enabled = true;
            inv.enabled = false;
        }
    }



    public void closing()
    {
        close = true;
    }
}
