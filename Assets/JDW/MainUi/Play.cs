using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
  
    public void GamePlay()
    {
        //Debug.Log("게임시작"); //TO DO : 다음 씬 만들어야됨
        SceneManager.LoadScene("map");
    }
}
