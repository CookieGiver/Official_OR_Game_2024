using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prism : MonoBehaviour
{
    public Transform mirror;
    private float targetAngle = 0;
    public int direction = 0;
    private float deltaAngle = 0;
    private float timeElapsed = 0f;

    private bool inRange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 0 && inRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                direction = -1;
                targetAngle = transform.rotation.eulerAngles.y + direction * 45;
                if (targetAngle < 0)
                {
                    targetAngle += 360;
                }
                timeElapsed = 0f;
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                direction = 1;
                targetAngle = transform.rotation.eulerAngles.y + direction * 45;
                if (targetAngle > 360)
                {
                    targetAngle -= 360;
                }
                timeElapsed = 0f;
            }
        }
        else
        {
            deltaAngle = Mathf.Max(0.1f, 1f-Mathf.Abs(timeElapsed - 0.7f))*direction*60*Time.deltaTime;
            transform.Rotate(new Vector3(0, deltaAngle, 0));
            if (direction == -1)
            {
                if (targetAngle - 90 < transform.rotation.eulerAngles.y && transform.rotation.eulerAngles.y < targetAngle)
                {
                    direction = 0;
                }
            }
            else
            {
                if (targetAngle + 90 > transform.rotation.eulerAngles.y && transform.rotation.eulerAngles.y > targetAngle)
                {
                    direction = 0;
                }
            }
            timeElapsed += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            inRange = false;
        }
    }
}
