using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Swordfish : MonoBehaviour
{
    private Rigidbody2D rb;
    public int dashLevel;
    public LayerMask objects;
    private int facingDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        facingDirection = Movement.facingDirection;
        if(Input.GetKeyDown(KeyCode.F)){
            dash();
        }
    }

    void dash(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector3.forward,20.0f,objects);
        transform.Translate(new Vector3(1,0,0) * dashLevel);

        if(hit){
            Debug.Log("Hit");
            Debug.DrawRay(transform.position,Vector3.forward,Color.green,5.0f);
        }
    }
}
