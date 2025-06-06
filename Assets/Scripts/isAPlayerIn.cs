using UnityEngine;

public class isAPlayerIn : MonoBehaviour
{
    public bool playerInSpace;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInSpace = true;

        }
        else
        {
            playerInSpace = false;
        }
    }
}
