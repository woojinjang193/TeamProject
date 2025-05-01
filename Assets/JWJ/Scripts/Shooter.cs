using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletpre;
    [SerializeField] Transform muzzlePoint;
    [SerializeField] ObjectPool bulletPool;
    [SerializeField] float fireDelay;


    [Range(10, 30)]
    [SerializeField] float bulletSpeed;

    private float lastFireTime = 0;

    public void Fire() //설명적기 
    {
        if (Time.time - lastFireTime < fireDelay)
        {
            return;
        }
        lastFireTime = Time.time;

        AudioManager.instance.PlaySfx(AudioManager.Sfx.ArrowRelease); //오디오 재생
        Invoke(nameof(FireSoundDelay), fireDelay);

        PooledObject instance = bulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);
        Rigidbody bulletRigibody = instance.GetComponent<Rigidbody>();
        bulletRigibody.velocity = muzzlePoint.forward * bulletSpeed;
        

    }

    public void Fire(float speed) //설명적기
    {
        if (Time.time - lastFireTime < fireDelay)
        {
            return;
        }
        lastFireTime = Time.time;


        PooledObject instance = bulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);
        Rigidbody bulletRigibody = instance.GetComponent<Rigidbody>();
        bulletRigibody.velocity = muzzlePoint.forward * speed;

    }

    private void FireSoundDelay()
    {
            
    }       

}

