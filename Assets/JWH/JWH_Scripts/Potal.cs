using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potal : MonoBehaviour
{
    public string targetSceneName;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetSceneName == null)
            {
                Debug.LogError(gameObject.name + "null");
                return; 
            }

            SceneManager.LoadScene(targetSceneName);
        }
    }
    
}
// 사용할 오브젝트에서
//Collider 컴포넌트 is Triger 체크하기
// 플레이어 태그 설정하기!

