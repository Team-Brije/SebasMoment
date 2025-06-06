using Mirror;
using UnityEngine;

public class SpawnjObjectManager : NetworkBehaviour
{
    public float bulletSpeed = 10f;

    [Command]
    public void SpawnBullet(GameObject bulletPrefab, Transform shootPoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Destroy(bullet, 5f);

        ActorType actor = bullet.GetComponent<ActorType>();
        if (actor != null)
        {
            actor.isProjectile = true;
        }

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            Vector3 shootDirection = shootPoint.forward;
            bulletRb.linearVelocity = shootDirection * bulletSpeed;
        }

        NetworkServer.Spawn(bullet);
    }
}
