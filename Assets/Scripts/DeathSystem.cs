using UnityEngine;
using System.Collections;

public class DeathSystem : HealthSystem
{
    public override void death()
    { 
        if(health <= 0)
        {
            Debug.Log("Dead");
            isDead= true;
            canRegen = false;
            StartCoroutine(Respawn());
        }
    }
    IEnumerator Respawn()
    {
        if(isDead)
        {
            yield return new WaitForSeconds(5f);
            isDead = false; 
            health = maxHealth;
            shield = maxShield;
            canRegen = true;
            Debug.Log("Respawned");    
        }
    }
    
}
