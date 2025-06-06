using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameSetter : MonoBehaviour
{
    public TMP_InputField nameInput;
    public Button continueButton = null;

    public static string DisplayName { get; private set; }

    private const string PlayerPrefsNameKey = "PlayerName";



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() => SetUpInputField();

    public void SetUpInputField()
    {
        if (PlayerPrefs.HasKey(PlayerPrefsNameKey)) { return; }

        string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);

        nameInput.text = defaultName;

        SetPlayerName(defaultName);
    }

    public void SetPlayerName(string name)
    {
        continueButton.interactable = !string.IsNullOrEmpty(name);
    }

    public void SavePlayerName()
    {
        DisplayName = nameInput.text;

        PlayerPrefs.SetString(PlayerPrefsNameKey, DisplayName);
    }
}
