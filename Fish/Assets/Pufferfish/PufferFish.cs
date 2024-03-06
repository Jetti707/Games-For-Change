using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class PufferFish : MonoBehaviour
{

    private GameObject player;

    private Vector3 playerPos;

    //Circle Attack vars

    public float speed = 2.0f;

    public GameObject Circle;

    public float radius = 5.0f;

    public float numOfObjects = 10.0f;

    [SerializeField]
    private float attackCooldown = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        player =  GameObject.Find("player");
        
    }

    // Update is called once per frame
    void Update()
    {

        
    
     if(Input.GetKeyDown(KeyCode.F) && attackCooldown <= 0)
     {
       attack();
     }
    if(attackCooldown > 0)
    {
      attackCooldown -= Time.deltaTime;
    }

    }

    
    void attack()
    {
        playerPos = player.transform.position;

        float angleStep = 360.0f / numOfObjects;

            float nextAngle = 2 * Mathf.PI / numOfObjects;

            float angle = 0; 

            attackCooldown = 1.0f;
            
            for(int i =0 ; i< numOfObjects ; i++)
            {
                float x = Mathf.Cos(angle) * radius;
                float y = Mathf.Sin(angle) * radius;

                var obj = Instantiate(Circle, playerPos, Quaternion.identity);
                var rb = obj.AddComponent<Rigidbody2D>();
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.velocity = new Vector2(x,y) * speed;
                angle += nextAngle;

                Destroy(obj,2.0f);
            }
    }

    
}
