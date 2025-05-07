using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : MonoBehaviour
{

    [SerializeField] private Transform character;
    private Renderer obstacleRenderer;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, character.position);
        Vector3 direction = (character.position - transform.position).normalized;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, distance))
        {
            Renderer hitRenderer = hit.transform.GetComponentInChildren<Renderer>();

            if (hitRenderer != null && hitRenderer != obstacleRenderer)
            {
                ResetPreviousRenderer(); // 이전 오브젝트 복원

                obstacleRenderer = hitRenderer;

                // 매테리얼 투명도 조정: 이유는 모르겠는데 맵 오브잭트들이 일정 투명도 아래로 내려가면 그냥 투명으로 변함
                Material mat = obstacleRenderer.material;
                Color c = mat.color;
                c.a = 0.3f;
                mat.color = c;

                Debug.Log("오브젝트 감지 & 투명화: " + hit.transform.name);
            }
        }
        else
        {
            ResetPreviousRenderer();
        }
    }

    void ResetPreviousRenderer()
    {
        if (obstacleRenderer != null)
        {
            Material mat = obstacleRenderer.material;
            Color c = mat.color;
            c.a = 1f;
            mat.color = c;

            obstacleRenderer = null;
        }
    }

}
