using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletSpeed = 10f;
    private int bulletsFired = 0;
    private bool isShooting = false;

    private StarterAssets.StarterAssetsInputs inputs;

    private void Awake()
    {
        inputs = GetComponent<StarterAssets.StarterAssetsInputs>();
    }

    void Update()
    {
        if (inputs.shoot && bulletsFired < 3 && !isShooting)
        {
            StartCoroutine(ShootWithDelay());
        }

        if (!inputs.shoot)
        {
            bulletsFired = 0;
            isShooting = false;
        }
    }

    private void Shoot()
    {
        if (bulletPrefab != null && shootPoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            Destroy(bullet, 5f);
            bulletsFired++;

            ActorType actor = bullet.GetComponent<ActorType>();
            if (actor != null)
            {
                actor.isProjectile = true;
            }

            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                bulletRb.linearVelocity = shootPoint.rotation * Vector3.forward * bulletSpeed;
            }

            if (bulletsFired >= 3)
            {
                inputs.ShootInput(false);
                Debug.Log("Máximo de balas alcanzado, apagando disparo.");
            }
        }
    }

    private IEnumerator ShootWithDelay()
    {
        isShooting = true;

        while (inputs.shoot && bulletsFired < 3)
        {
            yield return new WaitForSeconds(0.2f);

            if (bulletPrefab != null && shootPoint != null)
            {
                GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
                Destroy(bullet, 5f);
                bulletsFired++;

                ActorType actor = bullet.GetComponent<ActorType>();
                if (actor != null)
                {
                    actor.isProjectile = true;
                }

                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                if (bulletRb != null)
                {
                    bulletRb.linearVelocity = shootPoint.forward * bulletSpeed;
                }

                if (bulletsFired >= 3)
                {
                    inputs.ShootInput(false);
                    Debug.Log("Máximo de balas alcanzado, apagando disparo.");
                    break;
                }
            }
        }
    }

}
