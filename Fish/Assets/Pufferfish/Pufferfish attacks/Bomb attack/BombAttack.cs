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
       cols = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayer);
       timer -= Time.deltaTime;
       if(timer <= 0 && cols.Length == 0){
        startExplosion();
        Destroy(this.gameObject,2.0f);
       }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            rb.velocity = new Vector2(0,0);
            startExplosion();
            Destroy(this.gameObject);
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
