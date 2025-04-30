using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    
    public void GameExit()
    {
        Debug.Log("게임종료");
        Application.Quit();
    }
}
