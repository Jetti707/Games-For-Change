using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFirstBoss : MonoBehaviour
{

    public  Vector3 currentPos;
    [SerializeField]
    private float camSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      currentPos = transform.position;
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(1.0f,0.0f,0.0f) * camSpeed);
    }
}
