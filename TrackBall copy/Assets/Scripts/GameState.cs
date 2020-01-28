using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    int isVolumeON = 1;
    string controlType = "touch";
    int level = 1;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.HasKey("isVolumeON"))
        {
            isVolumeON = PlayerPrefs.GetInt("isVolumeON");
        }
        if (PlayerPrefs.HasKey("controlType"))
        {
            controlType = PlayerPrefs.GetString("controlType");
            Debug.Log("Loaded control type");
            Debug.Log(controlType);
        }
        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }
    }


    // Getters
    public int GetIsVolumeON()
    {
        return PlayerPrefs.GetInt("isVolumeON");
    }
    public string GetControlType()
    {
        return PlayerPrefs.GetString("controlType");
    }
    public int GetLevel()
    {
        return PlayerPrefs.GetInt("level");
    }

    // Setters
    public void SetLevel(int newLevel)
    {
        PlayerPrefs.SetInt("level", newLevel);
        PlayerPrefs.Save();
    }
    public void SetControlType(string newControlType)
    {
        PlayerPrefs.SetString("controlType", newControlType);
        PlayerPrefs.Save();
    }
    public void SetIsVolumeON(int newIsVolumeON)
    {
        PlayerPrefs.SetInt("isVolumeON", newIsVolumeON);
        PlayerPrefs.Save();
    }
}
