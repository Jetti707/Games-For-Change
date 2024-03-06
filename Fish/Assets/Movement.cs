using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    [SerializeField]
    private GameObject active;

    Rigidbody2D rb;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private LayerMask collisions;

    private float horizontal;
    private float vertical;

    public static int facingDirection = 1;



    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Update is called once per frame
    void Update()
    {
       checkInput();
    }

    void FixedUpdate()
    {
    rb.velocity = new Vector2(horizontal * movementSpeed , vertical * movementSpeed);
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
