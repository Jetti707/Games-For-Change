using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Swordfish : MonoBehaviour
{
    private Rigidbody2D rb;
    public int dashLevel;
    public LayerMask objects;
    public LayerMask Enemies;
    private int facingDirection;
    public GameObject swordAttack;
    public int attackVel;
    private float cooldown;
    [SerializeField]
    private float cooldownOrg;
    private bool cooldownOver = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        facingDirection = Movement.facingDirection;
        dash();
        attack();
        if(!cooldownOver)
        {
        cooldown -= Time.deltaTime;
            if(cooldown <= 0)
            {
                cooldownOver = true;
            }
        }
    }

    void attack(){
        if(Input.GetKeyDown(KeyCode.Space) && cooldownOver){
            int rotation = -90 * facingDirection;
            var obj = Instantiate(swordAttack,transform.position,Quaternion.Euler(0,0,rotation));
            var rb = obj.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = new Vector2(1 * facingDirection,0) * attackVel;
            cooldown = cooldownOrg;
            cooldownOver = false;
        }
    }

    void dash(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position,new Vector2(1,0) * facingDirection,5,objects);
        RaycastHit2D enemyBlock = Physics2D.Raycast(transform.position,new Vector2(1,0) * facingDirection,5,Enemies);   
        if(hit){
            Debug.DrawRay(transform.position,new Vector2(1,0) * facingDirection * 5,Color.green);
        }else if(enemyBlock){
            Debug.DrawRay(transform.position,new Vector2(1,0) * facingDirection *5 , Color.red);
            if(Input.GetKeyDown(KeyCode.F)){
            Debug.Log("enemy");
            Vector3 curEnemPos = enemyBlock.collider.transform.position;
            transform.Translate(new Vector3(curEnemPos.x - transform.position.x * facingDirection - 0.5f,0,0));
            }
        }else{
         if(Input.GetKeyDown(KeyCode.F)){
            Debug.Log("normal");
            transform.Translate(new Vector3(1,0,0) * dashLevel);
         }
        }
    }


   void OnCollisionEnter2D(Collision2D other){   
    Debug.Log("hit1");
    if(other.gameObject.tag == "Enemy")
    {
        Debug.Log("hit");
        other.gameObject.GetComponent<testEnemy>().Health-= 1;
    }
  }
}
