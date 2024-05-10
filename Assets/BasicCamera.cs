using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCamera : MonoBehaviour
{
    public Transform player;
    public Transform position;

    public float sensitivity = 3f;
    public Vector2 turn;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        if (player.gameObject.GetComponent<CharcMove>().pause == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            turn.x += Input.GetAxis("Mouse X") * sensitivity;
            
            if (transform.eulerAngles.x < 60 | transform.eulerAngles.x > 300)
            {

                turn.y += Input.GetAxis("Mouse Y") * sensitivity;
            }

            else if (transform.eulerAngles.x > 60 & Input.GetAxis("Mouse Y") * sensitivity > 0 & transform.eulerAngles.x < 180)
            {

                turn.y += Input.GetAxis("Mouse Y") * sensitivity;
            }

            else if (transform.eulerAngles.x < 300 & Input.GetAxis("Mouse Y") * sensitivity < 0 & transform.eulerAngles.x > 180)
            {

                turn.y += Input.GetAxis("Mouse Y") * sensitivity;
            }


            position.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
            position.position = player.position + Vector3.up * 1.5f;
        }
        if (player.gameObject.GetComponent<CharcMove>().pause)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
