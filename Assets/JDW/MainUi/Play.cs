using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public float delay = 2f;
   
    public void LoadSceneWithDelay(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }
    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
  
    public void GamePlay()
    {
        Debug.Log("게임시작"); 
        LoadSceneWithDelay("TestMap");
        
    }
   
}
