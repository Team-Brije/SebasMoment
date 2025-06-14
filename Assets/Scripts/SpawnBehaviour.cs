using Mirror.Examples.Basic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public static GameObject[] SpawnPoints;
    public static void SpawnPlayer(GameObject player)
    {
        foreach (GameObject point in SpawnPoints)
        {
            if (point.GetComponent<isAPlayerIn>().playerInSpace) continue;
            
            player.transform.position = point.transform.position;
        }
    }
}
