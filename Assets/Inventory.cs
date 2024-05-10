using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public Canvas self;
    public Image panel;
    public Transform player;
    private bool open = false;
    // Start is called before the first frame update
    void Start()
    {

        self.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.GetComponent<CharcMove>().pause == false)
        {
            if (Input.GetKey("e"))
            {
                self.enabled = true;
                player.gameObject.GetComponent<CharcMove>().pause = true;
                open = true;
            }
        }

        if (open)
        {
            if (Input.GetMouseButtonDown(0))
            {
                float left = (Screen.width / 2) - (panel.rectTransform.rect.width/2);
                float right = (Screen.width / 2) + (panel.rectTransform.rect.width/ 2);
                float top = (Screen.height / 2) - (panel.rectTransform.rect.height / 2);
                float bottom = (Screen.height / 2) + (panel.rectTransform.rect.height / 2);
                if (Input.mousePosition.x < left | Input.mousePosition.x > right | Input.mousePosition.y < top | Input.mousePosition.y > bottom)
                {
                    self.enabled = false;
                    player.gameObject.GetComponent<CharcMove>().pause = false;
                    open = false;
                }

            }
        }

    }



}
