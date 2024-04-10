using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField]
    private float movementSpeed;

    private float horizontal;
    private float vertical;

    public static int facingDirection = 1;

    public static Vector2 pos;



    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Update is called once per frame
    void Update()
    {
       pos = transform.position;
       checkInput();
    }

    void FixedUpdate()
    {
    rotateOnInput();
    rb.velocity = new Vector2(horizontal * movementSpeed , vertical * movementSpeed);
    }

    void rotateOnInput()
    {
        
        // transform.Rotate(new Vector3(1.0f,0.0f,0.0f), rotate, Space.Self);

    }

    void checkInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(horizontal == 1 && facingDirection == -1)
        {
            Flip();
        }else if(horizontal == -1 && facingDirection == 1)
        {
            Flip();
        }

    }
    
    void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
