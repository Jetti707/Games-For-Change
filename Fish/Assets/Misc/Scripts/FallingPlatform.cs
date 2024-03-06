using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class FallingPlatform : MonoBehaviour
{

    Rigidbody2D rb;

    [SerializeField]
    private float timer = 2.0f;

    private bool timerCounter = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Player" )
        {
             timerCounter = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timerCounter)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0 )
        {
            rb.isKinematic = false;
            rb.gravityScale = 2;
        }

        if(timer <= -5)
        {
            Object.Destroy(this.gameObject);
        }

    }
}
