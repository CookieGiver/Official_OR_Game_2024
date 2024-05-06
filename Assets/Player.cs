
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 box;
    public LayerMask layertohit;
    float velocity = 0;

    public float jumpForce = 200;
    public float moveSpeed = 5;

    float horizontalInput;
    float verticalInput;

    public Vector3 moveDirection;

    public float groundDrag;
    public float playerHeight;
    public LayerMask ground;
    bool grounded;

    public float sensitivity = 200f;
    public Vector2 turn;
    public Transform camera;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }
    private void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);


        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        Debug.Log(grounded);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpForce * Vector3.up);
            Debug.Log("Jumped");
        }
    }
    private void FixedUpdate()
    {
        movePlayer();


    }

    private void movePlayer()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
