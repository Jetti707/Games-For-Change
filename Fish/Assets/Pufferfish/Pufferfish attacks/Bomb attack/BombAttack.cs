using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : MonoBehaviour
{

    public int radius;
    public LayerMask enemyLayer;
    public Collider2D[] cols;
    private Rigidbody2D rb;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius,enemyLayer);
       cols = colliders;
       timer -= Time.deltaTime;
       if(timer <= 0){
        startExplosion();
        Destroy(this.gameObject);
       }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            rb.velocity = new Vector2(0,0);
            Invoke("startExplosion",3);
        }
    }

    private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }

    void startExplosion()
    {
        if(cols.Length > 0){
            foreach(Collider2D col in cols){
            var script = col.gameObject.GetComponent<Health>();
            script.curHealth -= 10;
        }
        }
        
    }
}
