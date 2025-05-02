using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potal : MonoBehaviour
{
    public static Potal PotalInstance;
    public string targetSceneName;
    public SavePlayer savePlayer;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))// 플레이어 태그 탐색
        {
            if (targetSceneName == null)
            {
                Debug.LogError($"{gameObject.name} 타겟씬 없음");
                return; 
            }

            

            if (savePlayer != null) // 체력저장
            {
                savePlayer.SaveHp();
            }
            else
            {
                Debug.LogError($"{gameObject.name} 체력없음");
            }

            SceneManager.LoadScene(targetSceneName);
            Debug.Log($"Loading scene: {targetSceneName}");
        }
    }
    
}
// 사용할 오브젝트에서
//Collider 컴포넌트 is Triger 체크하기
// 플레이어 태그 설정하기!
// SavePlayer 스크립트가 들어간 플레이어를 인스펙터에서 적용하기 @@@@@@@@@@@@@

