using UnityEngine;
using System.Collections.Generic;
using TMPro;
public class Leaderboard : MonoBehaviour
{
    public List<GameObject> playersList = new List<GameObject>();
    public List<PointsSystem> leaderList = new List<PointsSystem>();
    public List<TextMeshProUGUI> pointsText;
    public List<TextMeshProUGUI> NameText;

    public List<float> points;
    
    public GameObject players;

    public float playerStats;
    void Start()
    {
        List<float> points = new List<float>();
    }

    void Update()
    {
        ///aqui cambiar el input por lo que quieren que sea la condicional de instancear
        if (Input.GetKeyDown(KeyCode.E))
        {  
            leaderList.Add(Instantiate(players.GetComponent<PointsSystem>()));
        }
        /////

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
    public void TextChange()
    {
        foreach(TextMeshProUGUI text in pointsText)
        {
          
        }
    }
}
