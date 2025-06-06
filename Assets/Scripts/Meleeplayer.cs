using UnityEngine;

public class Meleeplayer : MonoBehaviour
{
    public float damage;
    public Animator anims;
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HealthSystem>(out HealthSystem vida))
        {
            vida.TakeDamage(damage);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            anims.SetTrigger("knifeAttack");
        }
    }
}
