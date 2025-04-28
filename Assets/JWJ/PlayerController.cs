using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigid;
    [SerializeField] float playerSpeed;
    [SerializeField] private Shooter shooter;

    private Vector3 inputVec;


    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }
    void Update()
    {
        PlayerInput();
        LookAtMouse();
        PlayerAttack();
    }

 private void PlayerInput()
 {
     float x = Input.GetAxis("Horizontal");
     float z = Input.GetAxis("Vertical");

     inputVec = new Vector3(x, 0, z).normalized;

 }

    private void Move()
    {
        rigid.velocity = inputVec * playerSpeed;
    }    

    private void LookAtMouse()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        
        if (plane.Raycast(cameraRay, out rayLength))
        {
            Vector3 lookDir = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(lookDir.x, transform.position.y, lookDir.z));
        }
    }


    private void PlayerAttack()
    {
        if (Input.GetMouseButtonDown(0)) // 0 = ÁÂÅ¬¸¯
        {
            shooter.Fire();
        }
    }
    }
