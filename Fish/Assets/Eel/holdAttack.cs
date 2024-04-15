using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdAttack : MonoBehaviour
{
    // private float howLongHeld = 0;
    private GameObject firstParent;
    private GameObject secondParent;
    private Eel secondParentScript;
    // Start is called before the first frame update
    void Start()
    {
        firstParent = transform.parent.gameObject;
        secondParent = firstParent.transform.parent.gameObject;
        secondParentScript = secondParent.GetComponent<Eel>();
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        if(secondParentScript.getHowLongHeld() == 0)
        {
            firstParent.transform.localScale -= new Vector3(firstParent.transform.localScale.x,0,0);
        }
        if(secondParentScript.getHowLongHeld() > secondParentScript.attackThreshold)
        {
            if(firstParent.transform.localScale.x <= 110.0f)
            {
            firstParent.transform.localScale += new Vector3(1.0f,0.0f,0.0f);
            }
        }
    }

}
