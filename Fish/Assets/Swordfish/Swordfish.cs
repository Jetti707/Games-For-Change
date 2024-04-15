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
    public float normalDashCooldown;
    //Attack cooldowns
    private float cooldown;
    private bool cooldownOver = true;
    [SerializeField]
    private float cooldownOrg;
    //Dash Cooldowns
    [SerializeField]
    private float dashCoolOrg;
    private bool dashCoolOver;
    private float dashCool;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        facingDirection = Movement.facingDirection;
        if(Input.GetKeyDown(KeyCode.Space) && dashCoolOver){
        dash();   
        }
        if(Input.GetKeyDown(KeyCode.F) && cooldownOver){
        attack();
        }
        if(!dashCoolOver){
            dashCool -= Time.deltaTime;
            if(dashCool <= 0){
                dashCoolOver = true;
            }
        }
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
            int rotation = -90 * facingDirection;
            var obj = Instantiate(swordAttack,transform.position,Quaternion.Euler(0,0,rotation));
            var rb = obj.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = new Vector2(1 * facingDirection,0) * attackVel;
            cooldown = cooldownOrg;
            cooldownOver = false;
        
    }

    void dash(){
        var script = GameObject.FindWithTag("Enemy").GetComponent<TrashBoss>();
        
        RaycastHit2D enemyBlock = Physics2D.Raycast(transform.position,new Vector2(1,0) * facingDirection,5,Enemies);   
        

        if(enemyBlock && enemyBlock.distance > 0.5f){
            Debug.Log("enemy Block");
            Vector3 curEnemPos = enemyBlock.collider.transform.position;
            transform.Translate(new Vector3((curEnemPos.x - transform.position.x) * facingDirection - 1.0f,0,0));   
            dashCoolOver = false;
            dashCool = dashCoolOrg;
            
        }else{
            transform.Translate(new Vector3(1,0,0) * dashLevel);
            dashCoolOver = false;
            dashCool = normalDashCooldown;
        }
        
    }


   void OnCollisionEnter2D(Collision2D other){  
    Debug.Log("Hit1");
    if(other.gameObject.tag == "Enemies")
    {
        Debug.Log("hit");
        other.transform.parent.gameObject.GetComponent<Health>().curHealth-= 1;
    }
  }
}
