using UnityEngine;

public class BulletToEnemy : MonoBehaviour
{    void OnCollisionEnter(Collision collision)
    {
        ActorType actor = collision.gameObject.GetComponent<ActorType>();
        if (actor != null && actor.isProjectile)
        {
            Debug.Log("Enemy Hitted");
        }
    }
}
