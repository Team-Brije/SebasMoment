using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    public float health;
    public float shield;
    public bool isTakingDmg;
    public bool canRegen;
    public float regenTimer=0;
    void Start()
    {
        
        health = 100f;
        shield = 50f;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(25);

        }
        RegenShield();
    }

    public void TakeDamage(float dmg)
    {
        shield -= dmg;
        isTakingDmg = true;
        canRegen = false;

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
        }
        if(canRegen)
        {
            StartCoroutine(RegenCouroutine());
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
}
