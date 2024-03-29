using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBoss : MonoBehaviour
{

    private Movement player;
    [SerializeField]
    private int amountToSpawn;
    [SerializeField]
    private GameObject trash;

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
        for(int i = 0; i < amountToSpawn ; i ++)
        {
        var obj = Instantiate(trash, transform.position, Quaternion.identity);
        var rb = obj.AddComponent<Rigidbody2D>();
        rb.isKinematic = true;
        }
        thrown = true;
    }
}
