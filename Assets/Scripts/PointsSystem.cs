using UnityEngine;

public class PointsSystem : MonoBehaviour
{
    public Leaderboard leaderboard;
    public float score;
    public int ID;
    void Start()
    {
        score = 0;
    }

    void Update()
    {     
        if (Input.GetKeyDown(KeyCode.E))
        {
            score++;
            Debug.Log(score);
        }
    }
}
