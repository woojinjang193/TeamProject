using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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

                // 머티리얼 알파 조정
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
