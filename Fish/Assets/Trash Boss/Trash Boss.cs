using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBoss : MonoBehaviour
{

    private Movement player;
    public int numOfObjects;
    public int radius;
    public GameObject Circle;
    // [SerializeField]
    // private int amountToSpawn;

    private bool thrown;

    private Vector2 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        thrown = false; 
        playerPos = Movement.pos;
    }

    // Update is called once per frame
    void Update()
    {
        if(!thrown)
        {
        throwTrash();

        }
    }

    // void jumpAttack(){
    //    transform.translate(new Vector2(Movement.pos.x,Movement.pos.y));
    // }

    public void throwTrash()
    {
        // for(int i = 0; i < amountToSpawn ; i ++)
        // {
        // var obj = Instantiate(trash, new Vector3(transform.position.x  + Random.Range(-5.0f, 5.0f) ,transform.position.y + Random.Range(-5.0f, 5.0f) ,0), Quaternion.identity);
        // var rb = obj.AddComponent<Rigidbody2D>();
        // rb.isKinematic = true;
        // rb.velocity = new Vector2(-1,0) * 10;
        // }
        // thrown = true;
         float angleStep = 360.0f / numOfObjects;

          float rotationStep = -120;

            float nextAngle = 2 * Mathf.PI / numOfObjects;

            float angle = 0; 
            
            for(int i = 0  ; i< numOfObjects; i++)
            {
                float x = Mathf.Cos(angle) * radius;
                float y = Mathf.Sin(angle) * radius;
                var obj = Instantiate(Circle, transform.position, Quaternion.Euler(0,0,rotationStep + angleStep));
                rotationStep += angleStep;
                var rb = obj.AddComponent<Rigidbody2D>();
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.velocity = new Vector2(x,y) * 10 ;
                angle += nextAngle;

                Destroy(obj,1.0f);
            }
            
                thrown = true;
    }
}
