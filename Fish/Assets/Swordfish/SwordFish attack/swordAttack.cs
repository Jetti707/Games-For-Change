using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public static float damage = 100.0f;

    public Health enemy;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Enemy"){
            enemy = other.GetComponent<Health>();
            enemy.curHealth -= damage;

            Destroy(obj);
        }else{
            Destroy(obj ,2.0f);
        }
    }
}
