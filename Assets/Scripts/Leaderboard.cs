using UnityEngine;
using System.Collections.Generic;
using TMPro;
public class Leaderboard : MonoBehaviour
{
    //public List<GameObject> playersList = new List<GameObject>();

    public PointsSystem PointsSystem;
    public List<PointsSystem> leaderList = new List<PointsSystem>();
    public List<int> idList = new List<int>();
    public int idCounter=0;

    public List<TextMeshProUGUI> pointsText;
    public List<TextMeshProUGUI> nameText;

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
            idList.Add(players.GetComponent<PointsSystem>().ID=idCounter);
            leaderList.Add(Instantiate(players.GetComponent<PointsSystem>()));
            idCounter++;
        
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
       
        TextChange();
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
        pointsText[0].text = points[0].ToString();
        pointsText[1].text = points[1].ToString();
        pointsText[2].text = points[2].ToString();
    }
    public void NameChange()
    {

    }
}
