using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    [SerializeField] Transform groundCheck;
    private int jumpHeight = 5;
    private int jumped;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumped = 2;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            jumped = 2;
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            jumped = jumped - 1;
            Debug.Log(jumped);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && jumped > 0)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            jumped = jumped - 1;
            Debug.Log(jumped);
        }
        

    }


    
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

    }

    bool isGrounded()
    {
        Collider[] hitcollider;
        hitcollider = Physics.OverlapSphere(groundCheck.position, 0.51f);
        return (hitcollider.Length > 1);

    }

}
