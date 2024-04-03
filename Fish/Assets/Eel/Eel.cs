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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        chargeAttack();
    }

    void chargeAttack()
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


        if(howLongHeld > attackThreshold)
            {
                Physics2D.Raycast(new Vector3(transform.position.x + 10, transform.position.y + 5,0),new Vector2(1,0) * Movement.facingDirection ,5.0f,Enemies);
                Debug.DrawRay(new Vector3(transform.position.x + 2.0f * Movement.facingDirection, transform.position.y + 0.25f,0),new Vector2(1,0) * Movement.facingDirection * 5.0f,Color.green);
            }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log(howLongHeld);
            howLongHeld = 0;
        }
    }

    void attack(){
            var obj = Instantiate(eelAttack,new Vector3(transform.position.x + 2.0f * Movement.facingDirection, transform.position.y + 0.25f,0 ),Quaternion.identity);
            var rb = obj.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = new Vector2(1 * Movement.facingDirection,0) * 5;
            cooldown = cooldownOrg;
            cooldownOver = false;
    }
}
