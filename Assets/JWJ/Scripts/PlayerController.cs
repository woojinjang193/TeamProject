using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigid;
    [SerializeField] float playerSpeed;
    [SerializeField] private Shooter shooter;
    [SerializeField] public float playerHP;
   // [SerializeField] public float playerAttack;
    [SerializeField] float knockbackPower;
    [SerializeField ]private float mouseSensitivity = 5f;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform cameraArm;

    //[SerializeField] private Stop pauseScript;
    //[SerializeField] private Animator animator;
    private float _maxHP;  // 맥스체력 저장공간
    public bool isKnockback = false;

    public float maxHP  
    {
        get { return _maxHP; }
    }
    public float curHP   //curHP 에 현재체력 계속 저장
    {
        get { return playerHP; }
    }

    private void Awake()
    {
        _maxHP = playerHP; // _maxHP = playerHP; //초기체력(맥스체력) 저장
                           //  Debug.Log("player 체력 초기화");
    }
    void Start() 
    {

        AudioManager.instance.PlayBgm(); // BGM 플레이

        // _maxHP = playerHP; //초기체력(맥스체력) 저장
        // Debug.Log("player 체력 초기화");


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
        LookAround();

        if (!isKnockback)
        {
            PlayerAttack();
        }
        
    }


    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
       

            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = (lookForward * moveInput.y + lookRight * moveInput.x).normalized;

            Player.forward = lookForward;
            transform.position += moveDir * Time.deltaTime * playerSpeed;
            
    }

    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSensitivity;
        Vector3 camAngle = cameraArm.rotation.eulerAngles;

        float x = camAngle.x - mouseDelta.y;

        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);  // 위쪽 제한
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f); // 아래쪽 제한
        }

        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }



    private void PlayerAttack() 
    {


        if (Input.GetMouseButtonDown(0))
        {

            shooter.Fire();
            //AudioManager.instance.PlaySfx(AudioManager.Sfx.ArrowRelease); //오디오 재생
            //animator.SetTrigger("Attack");


        }
        
    }
        


private void OnCollisionEnter(Collision collision)  //플레이어 데미지
{
if (collision.gameObject.CompareTag("Monster"))
{

    MonsterController monster = collision.gameObject.GetComponent<MonsterController>();
    BossController boss = collision.gameObject.GetComponent<BossController>();

    if (monster != null)  //몬스터한테 데미지
    {
        PlayerTakeDamage(monster.monsterAttack, monster.transform);
        Debug.Log("플레이어 체력" + playerHP);

        if (playerHP <= 0)
        {
            Debug.Log("으앙 쥬금ㅠ");

            gameObject.SetActive(false);
            GameManager.Instance.OnPlayerDide.Invoke();

        }
    }

    if (boss != null)  // 보스한테 데미지
    {
               
        PlayerTakeDamage(boss.bossAttack, boss.transform);
        Debug.Log("플레이어 체력" + playerHP);

        if (playerHP <= 0)
        {
            Debug.Log("으앙 쥬금ㅠ");

            gameObject.SetActive(false);
            GameManager.Instance.OnPlayerDide.Invoke();

        }
    }
 }
}

private void PlayerTakeDamage(float damage, Transform monsterTransform)
{
        BossController boss = monsterTransform.GetComponent<BossController>();

        if (boss != null && boss.isDead)
        {
            return;
        }

        else if (playerHP > 0 && isKnockback == false)
        {
                   playerHP -= damage;  
                DamageAction(monsterTransform);
        }


}

private void DamageAction(Transform monsterTransform)
{

        Debug.Log("플레이어 넉백");
        AudioManager.instance.PlaySfx(AudioManager.Sfx.PlayerGetDamaged); //오디오 재생

        Vector3 knockback = monsterTransform.forward;

rigid.velocity = knockback * knockbackPower;
isKnockback = true;
Invoke(nameof(EndKnockback), 0.5f);  // 넉백 시간
}

private void EndKnockback()
{
isKnockback = false;
}
}
