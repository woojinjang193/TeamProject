using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigid;
    [SerializeField] float playerSpeed;
    [SerializeField] private Shooter shooter;
    [SerializeField] float playerHP;
   // [SerializeField] public float playerAttack;
    [SerializeField] float knockbackPower;

    //[SerializeField] private Stop pauseScript;
    //[SerializeField] private Animator animator;


    private Vector3 inputVec;
    private bool isKnockback = false;

    void Start()
    {
 
    }

    private void FixedUpdate()
    {
        if (!isKnockback)
        {
            Move();
        }
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


        if (Input.GetMouseButtonDown(0))
        {
            shooter.Fire();
            //animator.SetTrigger("Attack");


        }
        
    }
        


private void OnCollisionEnter(Collision collision)
{
if (collision.gameObject.CompareTag("Monster"))
{
    MonsterController monster = collision.gameObject.GetComponent<MonsterController>();
    if (monster != null)
    {
        PlayerTakeDamage(monster.monsterAttack, monster.transform);
        Debug.Log("플레이어 체력" + playerHP);

        if (playerHP <= 0)
        {
            Debug.Log("으앙 쥬금ㅠ");
            gameObject.SetActive(false);
        }
    }


}
}

private void PlayerTakeDamage(float damage, Transform monsterTransform)
{
if (playerHP > 0)
{
    playerHP -= damage;
    DamageAction(monsterTransform);
}


}

private void DamageAction(Transform monsterTransform)
{
Vector3 knockback = monsterTransform.forward;

rigid.velocity = knockback * knockbackPower;
isKnockback = true;
Invoke(nameof(EndKnockback), 0.5f);
}

private void EndKnockback()
{
isKnockback = false;
}
}
