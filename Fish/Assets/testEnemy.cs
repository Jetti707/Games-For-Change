using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEnemy : MonoBehaviour
{   
    
    public float Health = 100;
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
    }

}
