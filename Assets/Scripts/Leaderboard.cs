using UnityEngine;
using System.Collections.Generic;

public class Leaderboard : MonoBehaviour
{
    public List<GameObject> leaderList = new List<GameObject>();
    public List<float> points;

    public float playerStats;
    void Start()
    {
        List<float> points = new List<float>();
    }

    
    void Update()
    {
       
        foreach (GameObject player in leaderList)
        {
            if (player != null)
            {
                if(points.Count<leaderList.Count)
                {
                    playerStats = player.GetComponent<DeathSystem>().score;
                    SortLowestToHighestPlayers();     
                }
            }
            else
            {
                return;
            }
        }
        points.Sort();
    }
    public void SortLowestToHighestPlayers()
    {
        points.Add(playerStats);
        points.Sort();
        
    }

}
