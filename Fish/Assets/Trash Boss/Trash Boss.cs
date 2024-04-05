using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBoss : MonoBehaviour
{

    private Movement player;
    private Vector2 playerPos;

    public int numOfObjects;
    public int radius;
    public GameObject Circle;
    [SerializeField]
    private LayerMask playerMask;
    
    [SerializeField]
    private float jumpCool;
    [SerializeField]
    private float jumpCoolOrg;
    private bool canJump;
    private bool jumping;

    [SerializeField]
    private float attack1Timer;
    private bool attack1TimerNotOver;
    private bool thrown;


    private CameraFirstBoss camScript;
    private Vector3 camPos;


    // Start is called before the first frame update
    void Start()
    {
        camScript = GameObject.FindWithTag("Camera").GetComponent<CameraFirstBoss>();
        thrown = false;
        jumping = false;
        playerPos = Movement.pos;
        attack1Timer = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = Movement.pos;
        if(!jumping)
        {
        move();
        }


        if(!thrown && !attack1TimerNotOver)
        {
        throwTrash();
        attack1TimerNotOver  = true;
        }

        if(attack1TimerNotOver){
            attack1Timer -= Time.deltaTime;
            if(attack1Timer <= 0){
                attack1TimerNotOver = false;
                attack1Timer = 3.0f;
            }
            thrown = false;
        }

        if(jumpCool <= 0 && attack1TimerNotOver)
        {
            doJumpAttack();
            jumpCool = jumpCoolOrg;
            canJump = false;
        }

        if(!canJump)
        {
            jumpCool -= Time.deltaTime;
        }
    }


    public void doJumpAttack()
    {
       transform.position = playerPos;
       jumping = true;
       Invoke("jumpAttack",5.0f);
    }

    public void jumpAttack(){    
       Collider2D [] cols = Physics2D.OverlapCircleAll(transform.position, radius,playerMask);
       if(cols.Length > 0 )
       {
        var script = cols[0].GetComponent<Health>();
        script.curHealth -=10;
       }
       jumping = false;
       resetBackToPosition();

    }

    public void throwTrash()
    {
         float angleStep = 360.0f / numOfObjects;
        

          float rotationStep = -120;

            float nextAngle = 2 * Mathf.PI / numOfObjects;

            float angle = 0; 
            
            for(int i = 0  ; i< numOfObjects; i++)
            {
                float x = Mathf.Cos(angle) * radius;
                float y = Mathf.Sin(angle) * radius;
                var obj = Instantiate(Circle, transform.position, Quaternion.Euler(0,0,rotationStep + angleStep));
                rotationStep += angleStep;
                var rb = obj.AddComponent<Rigidbody2D>();
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.velocity = new Vector2(x,y) * 10 ;
                angle += nextAngle;
            }
            
                thrown = true;
    }

     public void resetBackToPosition()
    {
        transform.position = new Vector3(16.88f,-1.26f,0.0f);
    }

    private void move()
    {
        camPos = camScript.currentPos;
        transform.position = new Vector3(camPos.x +26.07f , 0,0);
    }
}
