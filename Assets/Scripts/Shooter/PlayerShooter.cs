using UnityEngine;
using System.Collections;
using Mirror;

public class PlayerShooter : NetworkBehaviour
{
    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletSpeed = 10f;
    private int bulletsFired = 0;
    private bool isShooting = false;

    public GameObject cam;

    private StarterAssets.StarterAssetsInputs inputs;

    public SpawnjObjectManager spawnjObjectManager;

    private void Awake()
    {
        //if (!isLocalPlayer) { this.enabled = false; }
        inputs = GetComponent<StarterAssets.StarterAssetsInputs>();
        spawnjObjectManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnjObjectManager>();
    }

    void Update()
    {
        shootPoint.rotation = cam.transform.rotation;

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
            spawnjObjectManager.SpawnBullet(bulletPrefab,shootPoint);

            bulletsFired++;

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
