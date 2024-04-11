using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdAttack : MonoBehaviour
{
    private Eel parentScript;
    private Vector2 playerPos;
    public float increaseRate;
    private int facingDirection;
    // Start is called before the first frame update
    void Start()
    {
        parentScript = transform.parent.gameObject.GetComponent<Eel>();
    }

    // Update is called once per frame
    void Update()
    {
        facingDirection = Movement.facingDirection;
        playerPos = parentScript.transform.position;
        transform.localScale += new Vector3(increaseRate * facingDirection,0,0);
        transform.Translate(new Vector2(transform.position.x / 2 , 0));
        Debug.Log(transform.position);
    }
}
