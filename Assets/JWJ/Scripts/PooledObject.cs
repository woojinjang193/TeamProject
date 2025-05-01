using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Pool;

public class PooledObject : MonoBehaviour
{
    public ObjectPool returnPool;
    [SerializeField] float returnTime;
    private float timer;

    private void Start()
    {

    }
    private void OnEnable()
    {
        timer = returnTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ReturnPool();
        }
    }


    public void ReturnPool()
    {
        if (returnPool == null)
        {
            Destroy(gameObject);
        }
        else
        {
            returnPool.ReturnPool(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ReturnPool();

            AudioManager.instance.PlaySfx(AudioManager.Sfx.Hit); //오디오 재생
            Debug.Log("오브젝트 아야사운드");
   
        


       
    }

}
