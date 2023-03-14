using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    private PlayerMovement playerScript;
    public Image healthBar;
    public float healthAmount = 100;
    
void start(){
playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();

}
    private void Update()
    {
        if(healthAmount <= 0)
        {
         playerScript.isDead = true;
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(20);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            Healing(10);
        }
    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
        healthBar.fillAmount = healthAmount / 100;
    }

    public void Healing(float healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100;
    }

}