using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashThrown : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player"); 
        transform.position = new Vector2(transform.position.x - Random.Range(-10.0f, 10.0f) , transform.position.y - Random.Range(-10.0f, 10.0f));
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = player.transform.position - transform.position;   
        Destroy(this.gameObject,2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onTriggerEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Health playerHealth = GetComponent<Health>();
            playerHealth.curHealth -= 1;
        }
    }
}
