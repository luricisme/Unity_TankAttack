using TMPro;
using UnityEngine;

public class SAVESYSTEM : MonoBehaviour
{
    public TMP_InputField inputField;
    public void SaveData()
    {
        PlayerPrefs.SetString("PLAYER_NAME", inputField.text);
    }
    public void LoadData()
    {
        inputField.text = PlayerPrefs.GetString("PLAYER_NAME");
    }
    public void DeleData()
    {
        PlayerPrefs.DeleteKey("PLAYER_NAME");
    }

}
