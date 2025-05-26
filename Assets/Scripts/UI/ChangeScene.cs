using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    public bool isTitleSCreen;

    void Update()
    {
        if (isTitleSCreen && Input.GetKeyDown(KeyCode.E))
        {
            LoadScene();
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Loading Scene: " + sceneName);
    }
}
