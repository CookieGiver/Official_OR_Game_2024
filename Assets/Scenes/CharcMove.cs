
using UnityEngine;

public class CharcMove : MonoBehaviour
{
    public CharacterController control;
    public Vector3 box;
    public LayerMask layertohit;

    public Vector2 turn;
    public float sensitivity = 3f;
    public bool pause = false;
    void Update()
    {
        if (pause == false)
        {


            turn.x += Input.GetAxis("Mouse X") * sensitivity;
            turn.y += Input.GetAxis("Mouse Y") * sensitivity;
            transform.localRotation = Quaternion.Euler(0, turn.x, 0);
            if (Input.GetKey("d"))
            {
                Vector3 direction = new Vector3(Mathf.Sin((turn.x + 90) / 180 * Mathf.PI), 0, Mathf.Cos((turn.x + 90) / 180 * Mathf.PI));
                control.Move(direction * Time.deltaTime * 10);

            }
            if (Input.GetKey("w"))
            {
                Vector3 direction = new Vector3(Mathf.Sin(turn.x / 180 * Mathf.PI), 0, Mathf.Cos(turn.x / 180 * Mathf.PI));
                control.Move(direction * Time.deltaTime * 10);
            }
            if (Input.GetKey("s"))
            {
                Vector3 direction = new Vector3(-Mathf.Sin(turn.x / 180 * Mathf.PI), 0, -Mathf.Cos(turn.x / 180 * Mathf.PI));
                control.Move(direction * Time.deltaTime * 10);

            }
            if (Input.GetKey("a"))
            {
                Vector3 direction = new Vector3(Mathf.Sin((turn.x - 90) / 180 * Mathf.PI), 0, Mathf.Cos((turn.x - 90) / 180 * Mathf.PI));
                control.Move(direction * Time.deltaTime * 10);
            }

        }
    }
}
