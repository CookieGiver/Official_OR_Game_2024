using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform player;
    Transform position;

    public float sensitivity = 200f;
    public Vector2 turn;

    // Start is called before the first frame update
    void Start()
    {
        position = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        position.localRotation = Quaternion.Euler(-turn.y, position.localRotation.x, 0);

        position.position = player.position + Vector3.up * 0.5f;

    }
}
