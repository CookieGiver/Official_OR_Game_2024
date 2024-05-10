using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenLock : MonoBehaviour
{
    public string code;
    public Transform player;
    public Transform door;
    public bool active = false;
    public GameObject inputField;
    // Update is called once per frame
    void Update()
    {
        active = GetComponent<activate>().active;
        if (active)
        {
            inputField.transform.localScale = new Vector3 (1f, 1f, 1f);
            inputField.GetComponent<TMP_InputField>().Select();
            player.gameObject.GetComponent<CharcMove>().pause = true;
            string input = inputField.GetComponent<TMP_InputField>().text;
            if (input == code)
            {
                GetComponent<activate>().active = false;
                player.gameObject.GetComponent<CharcMove>().pause = false;
                door.gameObject.GetComponent<swing>().goal = 90;
                GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
            }
        }
        if (!active)
        {
            inputField.GetComponent<TMP_InputField>().text = "";
            inputField.transform.localScale = new Vector3(0f, 1f, 1f);

        }
    }


    public void deselect()
    {
        GetComponent<activate>().active = false;
        player.gameObject.GetComponent<CharcMove>().pause = false;
    }

}
