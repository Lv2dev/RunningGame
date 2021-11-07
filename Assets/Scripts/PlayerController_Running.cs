using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Running : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float jumpUpSpeed = 10f;
    public float jumpDownSpeed = 13f;
    public bool isJump = false;
    public float jumpLimit = 3f;
    public bool isSlide = false;
    public bool slideBtnPress = false;
    public Animator unityChanAnim;
    public enum PLAYERSTATE
    {
        IDLE = 0,
        JUMP,
        DOWN,
        SLIDE,
        HIT
    }
    public PLAYERSTATE playerState;
    public int jumpCnt = 0;
    public int jumpCntMax = 2;
    public int playerHp = 5;
    public int PlayerMaxHp = 5;
    public int itemCnt = 0;
    public int boosterCnt = 0;
    public int boosterMax = 10;
    public float boosterCurTime = 0;
    public float boosterCoolTime = 5f;
    public bool isBooster = false;
    public bool isGod = false;
    public bool isDead = false;
    public float hitCurTime;
    public bool isHit = false;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        unityChanAnim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        switch (playerState)
        {
            case PLAYERSTATE.IDLE:
                isJump = false;
                isSlide = false;
                transform.position = new Vector3(transform.position.x, 0, 0);
                jumpCnt = 0;
                jumpLimit = 2f;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    playerState = PLAYERSTATE.SLIDE;
                }
                break;
            case PLAYERSTATE.JUMP:
                isJump = true;
                transform.Translate(0, jumpUpSpeed * Time.deltaTime, 0);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jumpLimit += transform.position.y;
                    jumpCnt++;
                }
                if (transform.position.y > jumpLimit)
                {
                    playerState = PLAYERSTATE.DOWN;
                }
                break;
            case PLAYERSTATE.DOWN:
                transform.Translate(0, -jumpDownSpeed * Time.deltaTime, 0);
                if (Input.GetKey(KeyCode.Space))
                {
                    jumpLimit += transform.position.y;
                    jumpCnt++;
                    playerState = PLAYERSTATE.JUMP;
                }
                if (transform.position.y < 0.5f)
                {
                    playerState = PLAYERSTATE.IDLE;
                }
                break;
            case PLAYERSTATE.SLIDE:
                isSlide = true;
                if (Input.GetKeyUp(KeyCode.LeftControl))
                {
                    playerState = PLAYERSTATE.IDLE;
                    isSlide = false;
                }
                break;
            case PLAYERSTATE.HIT:
                isHit = true;
                hitCurTime += Time.deltaTime;
                AnimatorClipInfo[] m_CurrentClipInfo;
                m_CurrentClipInfo = unityChanAnim.GetCurrentAnimatorClipInfo(0);
                transform.position = new Vector3(transform.position.x, 0, 0);
                if (hitCurTime > m_CurrentClipInfo[0].clip.length)
                {
                    isHit = false;
                    hitCurTime = 0;
                    playerState = PLAYERSTATE.IDLE;
                }
                break;
            default:
                break;
        }
    }
    public void Jump()
    {
        playerState = PLAYERSTATE.JUMP;
        jumpCnt++;
    }
    public void SlidingKeyDown()
    {
        slideBtnPress = true;
    }
    public void SlidingKeyUp()
    {
        slideBtnPress = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            playerHp--;
            playerState = PLAYERSTATE.HIT;
            if (playerHp < 0)
                isDead = true;
        }
        if (other.gameObject.tag == "Item")
        {
            itemCnt++;
        }
        if (other.gameObject.tag == "Booster")
        {
            boosterCnt++;
            if (boosterCnt >= boosterMax)
            {
                isBooster = true;
                isGod = true;
            }
        }
    }
}