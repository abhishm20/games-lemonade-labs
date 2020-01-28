using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    private GameState gameState;

    private void Awake()
    {
        gameState = GetComponent<OptionMenu>().GetComponentInChildren<GameState>();
    }

    public void SetControlType(string controlType)
    {
        gameState.SetControlType(controlType);
    }

    public void SetIsVolumeON(int isVolumeON)
    {
        gameState.SetIsVolumeON(isVolumeON);
    }

}
