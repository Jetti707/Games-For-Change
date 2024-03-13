using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : MonoBehaviour
{

    public int radius;
    public List<Collider2D> enemyColliders;
    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //    Physics2D.OverlapCircle(transform.position, radius,enemyLayer,enemyColliders);
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        Debug.Log("hit");
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("hit2");
            startExplosion();

            foreach(var hitColliders in enemyColliders){
                Debug.Log(enemyColliders);
            }
        }
    }

    private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }

    void startExplosion()
    {

    }
}
