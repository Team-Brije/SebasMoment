using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    public float health;
    public float maxHealth = 100f;
    public float maxShield = 50f;
    public float shield;
    public float regenTimer = 0;
  

    public bool isTakingDmg;
    public bool canRegen;
    public bool isDead;

    void Start()
    {
        health = maxHealth;
        shield = maxShield;
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(25);
            
        }
        RegenShield();
        death();     
    }

    public void TakeDamage(float dmg)
    {
        shield -= dmg;
        isTakingDmg = true;
        canRegen = false;
        regenTimer = 0;

        if (shield < 0)
        {
            shield = 0;
            health -= dmg;
            if (health <= 0)
            {
                health = 0;
            }
        }

    }
    public void RegenShield()
    {
        if(isTakingDmg)
        {
            regenTimer += Time.deltaTime;
            if(regenTimer>5)
            {
                isTakingDmg = false;
                canRegen = true;
                regenTimer = 0;
            }
            if (canRegen)
            {
                StartCoroutine(RegenCouroutine());
                
            }
        }
        
    }
    IEnumerator RegenCouroutine()
    {
        while (shield < 50)
        {
            shield += 10;
            if (shield > 50)
            {
                shield = 50;
                canRegen=false;
            }
            yield return new WaitForSeconds(1f);
        }
    }
    public virtual void death()
    {

    }
}
