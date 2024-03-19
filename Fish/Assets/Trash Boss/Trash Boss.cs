using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBoss : MonoBehaviour
{

    private Movement player;
<<<<<<< Updated upstream
=======
    [SerializeField]
    private int amountToSpawn;
    [SerializeField]
    private GameObject trash;
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
        Invoke("jumpAttack",2.0f);
    }

    void jumpAttack(){
        // transform.translate(new Vector2(Movement.pos.x,Movement.pos.y));
=======
        if(!thrown)
        {
        Debug.Log("throwing");
        throwTrash();

        }
    }

    // void jumpAttack(){
    //    transform.translate(new Vector2(Movement.pos.x,Movement.pos.y));
    // }

    void throwTrash()
    {
        for(int i = 0; i < amountToSpawn ; i ++)
        {
        Debug.Log("i");
        var obj = Instantiate(trash, transform.position, Quaternion.identity);
        var rb = obj.AddComponent<Rigidbody2D>();
        rb.velocity = new Vector2(playerPos.x, playerPos.y);
        }
        thrown = true;
>>>>>>> Stashed changes
    }
}
