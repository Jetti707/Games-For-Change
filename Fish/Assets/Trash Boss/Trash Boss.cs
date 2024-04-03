using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBoss : MonoBehaviour
{

    private Movement player;
    public int numOfObjects;
    public int radius;
    public GameObject Circle;

    [SerializeField]
    private float attack1Timer;
    private bool attack1TimerCount;

    [SerializeField]
    private float attack2Timer;

    private bool thrown;

    private Vector2 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        thrown = false; 
        playerPos = Movement.pos;
        attack1Timer = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = Movement.pos;
        if(!thrown && !attack1TimerCount)
        {
        throwTrash();
        attack1TimerCount  = true;
        }

        if(attack1TimerCount){
            attack1Timer -= Time.deltaTime;
            if(attack1Timer <= 0){
                attack1TimerCount = false;
                attack1Timer = 10.0f;
            }
            thrown = false;
        }
    }

    void onDrawGizmos()
    {
        // Gizmos.DrawCircle(transform.position,radius);
    }

    public void doJumpAttack()
    {
       transform.position = playerPos;
        Invoke("jumpAttack",5.0f);
    }

    public void jumpAttack(){    

       Collider2D [] cols = Physics2D.OverlapCircleAll(transform.position, radius);
       if(cols.Length > 0 )
       {
        var script = cols[0].GetComponent<Health>();
        script.curHealth -=10;
        Debug.Log(cols.Length);
        Debug.Log("Hit player");
       }

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
}
