using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Title")  // 타이틀 씬 이름 정확히 쓰세요
        {
            GameObject btn = GameObject.Find("PlayButton"); // 버튼 오브젝트 이름
            if (btn != null)
            {
                btn.SetActive(true);  // 버튼 다시 켜기
                Debug.Log("Play 버튼 다시 활성화됨");
            }
        }
    }
}
