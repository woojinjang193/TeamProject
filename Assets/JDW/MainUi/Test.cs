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
        if (scene.name == "Title")  // Ÿ��Ʋ �� �̸� ��Ȯ�� ������
        {
            GameObject btn = GameObject.Find("PlayButton"); // ��ư ������Ʈ �̸�
            if (btn != null)
            {
                btn.SetActive(true);  // ��ư �ٽ� �ѱ�
                Debug.Log("Play ��ư �ٽ� Ȱ��ȭ��");
            }
        }
    }
}
