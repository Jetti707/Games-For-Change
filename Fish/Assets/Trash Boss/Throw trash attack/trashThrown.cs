using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashThrown : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Destroy(this.gameObject,10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Health playerHealth = player.GetComponent<Health>();
            playerHealth.curHealth -= 10;
            Destroy(this.gameObject);
        }else{
            Destroy(this.gameObject,5.0f);
        }
    }
}
