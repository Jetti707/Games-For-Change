using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class PufferFish : MonoBehaviour
{


    //Circle Attack vars

    public float speed = 2.0f;

    public GameObject Circle;
    public GameObject Bomb;

    private int facingDirection;

    public float radius = 5.0f;

    public float numOfObjects = 10.0f;

    [SerializeField]
    private float attackCooldown = 0.5f;

    //Sprite vars
    public Sprite norm;
    public Sprite inflated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     facingDirection = Movement.facingDirection;
     if(Input.GetKeyDown(KeyCode.F) && attackCooldown <= 0)
     {
       attack();
     }
     if(Input.GetKeyDown(KeyCode.Space) && attackCooldown <= 0 )
     {
      explode();
     }
    if(attackCooldown > 0)
    {
      attackCooldown -= Time.deltaTime;
    }

    }

    void explode()
    {

    var obj = Instantiate(Bomb, transform.position, Quaternion.identity);
    var rb = obj.AddComponent<Rigidbody2D>();

    rb.bodyType = RigidbodyType2D.Kinematic;
    rb.velocity = new Vector2(1,0) * facingDirection;
    }

    
    void attack()
    {

        this.gameObject.GetComponent<SpriteRenderer>().sprite = inflated;

        Invoke("changeBackToNorm",0.5f);

        float angleStep = 360.0f / numOfObjects;

          float rotationStep = -120;

            float nextAngle = 2 * Mathf.PI / numOfObjects;

            float angle = 0; 

            attackCooldown = 1.0f;
            
            for(int i =0 ; i< numOfObjects ; i++)
            {
                float x = Mathf.Cos(angle) * radius;
                float y = Mathf.Sin(angle) * radius;

                var obj = Instantiate(Circle, transform.position, Quaternion.Euler(0,0,rotationStep + angleStep));
                rotationStep += angleStep;
                var rb = obj.AddComponent<Rigidbody2D>();
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.velocity = new Vector2(x,y) * speed;
                Debug.Log("Obj " + i + " " + (rotationStep + angleStep));
                angle += nextAngle;

                Destroy(obj,2.0f);
            }
    }

    void changeBackToNorm(){
      this.gameObject.GetComponent<SpriteRenderer>().sprite = norm;
    }

    
}
