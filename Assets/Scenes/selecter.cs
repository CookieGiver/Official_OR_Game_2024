using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class selector : MonoBehaviour
{
    public LayerMask layermask;
    public LayerMask objects;
    public LayerMask items;
    // Start is called before the first frame update
    public GameObject target;
    public Transform player;
    public List<string> inv;
    public GameObject cross1;
    public GameObject cross2;
    public GameObject selected;
    public GameObject selectimg;
    public GameObject baseimg;

    private float countdown = 0f;
    void Update()
    {
        countdown -= 1;
        if (player.gameObject.GetComponent<CharcMove>().pause)
        {
            countdown = 10f;
        }
            if (player.gameObject.GetComponent<CharcMove>().pause == false & countdown < 0)
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            cross1.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            cross2.GetComponent<RectTransform>().localScale = new Vector3(0, 1, 1);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, fwd, out hit, 10, layermask))
            {
                cross1.GetComponent<RectTransform>().localScale = new Vector3(0, 1, 1);
                cross2.GetComponent<RectTransform>().localScale = new Vector3(2, 1, 1);
            }


            if (Input.GetMouseButtonDown(0))
            {


                RaycastHit hit2;
                if (Physics.Raycast(transform.position, fwd, out hit2, 10, objects))
                {
                    target = hit2.collider.gameObject;
                    target.GetComponent<Transform>().position += new Vector3(1000, 0, 0);

                    Debug.Log(target.name);
                    inv.Add(target.name);

                }


                if (Physics.Raycast(transform.position, fwd, out hit2, 10, items))
                {
                    target = hit2.collider.gameObject;
                    target.gameObject.GetComponent<activate>().active = true;



                }
            }
        }
        for (int j = 0; j < inv.Count; j+= 1)
        {

            GameObject picture = GameObject.Find(inv[j] + " img");
            Image rt = picture.GetComponent<Image>();
            GameObject button = GameObject.Find("Button (" + (j + 1) + ")");

            Image buttonimg = button.GetComponent<Image>();
            buttonimg.sprite = rt.sprite;
            button.GetComponentInChildren<TMP_Text>().text = inv[j];



        }

        if (selected != null)
        {
            GameObject picture = GameObject.Find(selected.name + " img");
            Image rt = picture.GetComponent<Image>();
            Image img = selectimg.GetComponent<Image>();
            img.sprite = rt.sprite;

        }
        else
        {
            Image rt = baseimg.GetComponent<Image>();
            Image img = selectimg.GetComponent<Image>();
            img.sprite = rt.sprite;
        }
    }
    public void Pressed(int num)
    {
        if (num <= inv.Count)
        {
            GameObject picture = GameObject.Find(inv[num-1]);
            selected = picture;
        }
        else
        {
            selected = null;
        }
    }

}   
