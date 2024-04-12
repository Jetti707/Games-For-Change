using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Eel : MonoBehaviour
{
    [SerializeField]
    private float howLongHeld = 0;

    private float cooldown;
    private bool cooldownOver = true;
    [SerializeField]
    private float cooldownOrg;

    public GameObject eelAttack;

    public LayerMask Enemies;

    public float attackThreshold;

    private SpriteRenderer sp;


    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.F) && cooldownOver)
        {
            attack();
        }
        if(!cooldownOver)
        {
           cooldown -= Time.deltaTime;
           if(cooldown <= 0)
           {
            cooldownOver = true;
           }
        }

        if(Input.GetKey(KeyCode.Space))
        {
            howLongHeld += Time.deltaTime;
        }

         if(Input.GetKeyUp(KeyCode.Space))
        {
            this.GetComponent<Movement>().enabled = true;
            howLongHeld = 0;
        }
    }

    public float getHowLongHeld()
    {
        return howLongHeld;
    }

    void FixedUpdate()
    {
        chargeAttack();
    }

    void chargeAttack()
    {


        if(howLongHeld > attackThreshold)
            {
                this.GetComponent<Movement>().enabled = false;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                RaycastHit2D hit = Physics2D.Raycast(new Vector3(transform.position.x + 2.0f, transform.position.y + 0.25f,0),new Vector2(1,0) * Movement.facingDirection ,35.0f,Enemies);
                Debug.DrawRay(new Vector3(transform.position.x + 2.0f, transform.position.y + 0.25f,0),new Vector2(1,0) * Movement.facingDirection *35.0f,Color.green);
                if(hit)
                {
                 var enemyHealth = hit.transform.gameObject.GetComponent<Health>();
                 enemyHealth.curHealth -= 1;
                }
            }

    }

    void attack(){
            var obj = Instantiate(eelAttack,new Vector3(transform.position.x + 2.0f * Movement.facingDirection, transform.position.y + 0.25f,0 ),Quaternion.identity);
            var rb = obj.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = new Vector2(1 * Movement.facingDirection,0) * 5;
            cooldown = cooldownOrg;
            cooldownOver = false;
            Destroy(obj,2.5f);
    }

   
}


