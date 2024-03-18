using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBoss : MonoBehaviour
{

    private Movement player;
    [SerializeField]
    private GameObject trash;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("jumpAttack",2.0f);
    }

    // void jumpAttack(){
    //    transform.translate(new Vector2(Movement.pos.x,Movement.pos.y));
    // }

    void throwTrash()
    {
        var obj = Instantiate(trash, transform.position, Quaternion.identity);
    }
}
