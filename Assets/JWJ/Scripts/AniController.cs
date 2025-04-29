using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniController : MonoBehaviour
{

    public Animator anima;
    private PlayerController playerController;
    private bool wasKnockback = false;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        playerController = GetComponentInParent<PlayerController>();
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

        bool isBack = Input.GetKey(KeyCode.S);
        anima.SetBool("isBack", isBack);

        bool isLeft = Input.GetKey(KeyCode.A);
        anima.SetBool("isLeft", isLeft);

        bool isRight = Input.GetKey(KeyCode.D);
        anima.SetBool("isRight", isRight);

        if (playerController.isKnockback && !wasKnockback)
        {
            anima.SetBool("isKnockback", true);
            wasKnockback = true;
            Debug.Log("플레이어 넉백모션");
        }
        else if (!playerController.isKnockback && wasKnockback)
        {
            anima.SetBool("isKnockback", false);
            wasKnockback = false;
        }


        //  bool iForward= Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        //  anima.SetBool("isMoving", iForward);



    }
}
