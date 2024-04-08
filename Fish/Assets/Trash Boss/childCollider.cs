using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childCollider : MonoBehaviour
{
    private TrashBoss bossScript;
    // Start is called before the first frame update
    void Start()
    {
     bossScript = transform.parent.gameObject.GetComponent<TrashBoss>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(bossScript.jumping)
        {
            this.GetComponent<CapsuleCollider2D>().isTrigger = true;
        }else
        {
            this.GetComponent<CapsuleCollider2D>().isTrigger = false;
        }
    }
}
