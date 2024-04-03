using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class displayHealth : MonoBehaviour
{
    public TextMeshProUGUI healthInfo;
    private Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        // Display health as "Health: curHealth/maxHealth"
        healthInfo.text = "Health: " + playerHealth.curHealth + "/" + playerHealth.maxHealth;
    }
}
