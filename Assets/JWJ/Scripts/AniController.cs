using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniController : MonoBehaviour
{

    public Animator anima;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            anima.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anima.SetTrigger("Test1");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anima.SetTrigger("Test2");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anima.SetTrigger("Test3");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            anima.SetTrigger("Test4");
        }

        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        anima.SetBool("isMoving", isMoving);

        
        
    }
}
