using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class HealthCanvas : MonoBehaviour
{
    public Image HealthBar;
    public Image Shieldbar;
    public Leaderboard leaderboard;
    public TextMeshProUGUI xd;

    public PointsSystem pointsSystem;
    public HealthSystem healthSystem;
    void Update()
    {
        ChangeImage();
        ChangeScore();
    }
    public void ChangeImage()
    {
        HealthBar.fillAmount = healthSystem.health / healthSystem.maxHealth;
        Shieldbar.fillAmount = healthSystem.shield / healthSystem.maxShield;
    }
    public void ChangeScore()
    {
    }
}
