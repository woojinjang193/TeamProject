using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AniController : MonoBehaviour
{

    public Animator anima;
    private PlayerController playerController;
    private BossController bossController;
    private bool wasKnockback = false;

    private bool isFStepPlaying = false;
    public bool isRolling = false;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        playerController = GetComponentInParent<PlayerController>();
        bossController = FindObjectOfType<BossController>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anima.SetTrigger("Attack");
        }



        bool isForward = Input.GetKey(KeyCode.W);
        anima.SetBool("isForward", isForward);

        if (isForward == true && isFStepPlaying == false)
        {
            AudioManager.instance.PlaySfx(AudioManager.Sfx.FootStep);
            isFStepPlaying = true;
            Invoke(nameof(FootStepSFXDelay), 0.4f);
        }


        bool isBack = Input.GetKey(KeyCode.S);
        anima.SetBool("isBack", isBack);

        if (isBack == true && isFStepPlaying == false)
        {
            AudioManager.instance.PlaySfx(AudioManager.Sfx.FootStep);
            isFStepPlaying = true;
            Invoke(nameof(FootStepSFXDelay), 0.5f);
        }

        bool isLeft = Input.GetKey(KeyCode.A);
        anima.SetBool("isLeft", isLeft);

        if (isLeft == true && isFStepPlaying == false)
        {
            AudioManager.instance.PlaySfx(AudioManager.Sfx.FootStep);
            isFStepPlaying = true;
            Invoke(nameof(FootStepSFXDelay), 0.5f);
        }

        bool isRight = Input.GetKey(KeyCode.D);
        anima.SetBool("isRight", isRight);

        if (isRight == true && isFStepPlaying == false)
        {
            AudioManager.instance.PlaySfx(AudioManager.Sfx.FootStep);
            isFStepPlaying = true;
            Invoke(nameof(FootStepSFXDelay), 0.5f);
        }



        if (playerController.isKnockback && !wasKnockback)
        {

            if (playerController.isHitByBoss && bossController.isDashing)
            {
                anima.SetTrigger("isHitByDash");
                wasKnockback = true;
                Debug.Log("보스 넉백 모션 실행");
            }

            if (playerController.isHitByMonter == true)
            {
                anima.SetBool("isHitByMonster", true);
                wasKnockback = true;
                Debug.Log("플레이어 몬스터 넉백모션");
            }


        }
        else if (!playerController.isKnockback && wasKnockback)
        {
            anima.SetBool("isHitByDash", false);
            anima.SetBool("isHitByMonster", false);
            wasKnockback = false;
        }


        //  bool iForward= Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        //  anima.SetBool("isMoving", iForward);



    }

    public void Rolling()
        {
            anima.SetTrigger("Rolling");
            isRolling = true;
            Invoke(nameof(Endrolling), 1f);
        }


private void FootStepSFXDelay()
    {
        isFStepPlaying = false;
    }

    private void Endrolling()
    {
        isRolling = false;
    }
}
