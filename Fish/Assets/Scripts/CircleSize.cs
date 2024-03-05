using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSize : MonoBehaviour
{
    public float speed = 3.0f;
    public GameObject circle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        circle.transform.position = new Vector3(0,0,0);
        circle.transform.localScale = new Vector3(1,1,1);
    }
}
