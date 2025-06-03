using UnityEngine;
using System.Collections.Generic;

public class Leaderboard : MonoBehaviour
{
    public List<PointsSystem> leaderList = new List<PointsSystem>();
    public List<float> points;

    public float playerStats;
    void Start()
    {
        List<float> points = new List<float>();
    }

    
    void Update()
    {
       
        foreach (PointsSystem player in leaderList)
        {
            if (player != null)
            {
                if(points.Count<leaderList.Count)
                {
                    playerStats = player.score;
                    SortLowestToHighestPlayers();                       
                }
            }
            else
            {
                return;
            }
        }
        for (int i = 0; i < leaderList.Count; i++)
        {
            points[i] = leaderList[i].score; 
        }
    }
    public void SortLowestToHighestPlayers()
    {
        points.Add(playerStats);
        points.Sort();
        
    }
    public void Updatelist(int ID)
    {
        foreach (PointsSystem Psystem in leaderList)
        {
            if(Psystem.ID == ID)
            {

                break;
            }
        }
        
    }
}
