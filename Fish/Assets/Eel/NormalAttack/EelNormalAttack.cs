using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EelNormalAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
        other.GetComponent<Health>().curHealth -= 100.0f;
        Destroy(this.gameObject);
        }
    }
}
