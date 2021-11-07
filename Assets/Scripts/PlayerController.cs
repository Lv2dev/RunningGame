using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float jumpUSpeed = 10f;
    public float jumpDSpeed = 13f;
    public bool isJump = false;
    public float jumpLimit = 3f;
    public bool isSlide = false;
    public bool slideBtnPress = false;
    public Animator unityChanAnim;
    public GameObject panel;
    public enum JUMPSTATE
    {
        IDLE = 0,
        JUMP,
        DOWN,
        SLIDE,
        HIT
    }
    public JUMPSTATE jumpState;
    public int jumpCnt = 0;
    public int jumpCntMax = 2;
    public int playerHP = 10;
    public int playerMaxHp = 10;
    public int itemCnt = 0;
    public int boosterCnt = 0;
    public int boosterMax = 10;
    public float boosterCurTime = 0;
    public float boosterCoolTime = 5f;
    public bool isBooster = false;
    public bool isGod;
    public bool isDead = false;
    public GameSpeedMgr gameSpeedMgr;
    public float hitCurTime;
    public bool isHit = false;
    public UIManager ui;

    //회전에서 사용
    public bool isLeftRotate;
    public bool isRightRotate;
    public bool isPass;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        unityChanAnim = GetComponentInChildren<Animator>();
        gameSpeedMgr = GameObject.Find("GameSpeedMgr").GetComponent<GameSpeedMgr>();
        isLeftRotate = false;
        isRightRotate = false;
        isPass = false;
        itemCnt = 0;
        playerHP = 10;
        ui = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void Update()
    {
        if (playerHP <= 0)
        {
            isDead = true;
        }
        switch (jumpState)
        {
            case JUMPSTATE.IDLE:
                isJump = false;
                isSlide = false;
                transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
                jumpCnt = 0;
                jumpLimit = 2f;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jumpState = JUMPSTATE.JUMP;
                    jumpCnt++;
                }
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    jumpState = JUMPSTATE.SLIDE;
                }
                if (slideBtnPress)
                {
                    jumpState = JUMPSTATE.SLIDE;
                }
                break;
            case JUMPSTATE.JUMP:
                isJump = true;
                if (jumpCnt < jumpCntMax)
                {
                    transform.Translate(0, jumpUSpeed * Time.deltaTime, 0);
                }
                else if(transform.position.y < jumpLimit)
                {
                    transform.Translate(0, jumpUSpeed * Time.deltaTime, 0);
                }
                else
                {
                    jumpState = JUMPSTATE.DOWN;
                }
                if (transform.position.y > jumpLimit)
                {
                    jumpState = JUMPSTATE.DOWN;
                }
                break;
            case JUMPSTATE.DOWN:
                transform.Translate(0, -jumpUSpeed * Time.deltaTime, 0);
                if (transform.position.y < 0.5f)
                {
                    jumpState = JUMPSTATE.IDLE;
                }
                break;
            case JUMPSTATE.SLIDE:
                isSlide = true;
                if (Input.GetKeyUp(KeyCode.LeftControl))
                {
                    jumpState = JUMPSTATE.IDLE;
                    isSlide = false;
                }
                if (slideBtnPress == false)
                {
                    jumpState = JUMPSTATE.IDLE;
                    isSlide = false;
                }
                break;
            case JUMPSTATE.HIT:
                isHit = true;
                hitCurTime += Time.deltaTime;
                AnimatorClipInfo[] m_CurrentClipInfo;
                m_CurrentClipInfo = unityChanAnim.GetCurrentAnimatorClipInfo(0);
                gameSpeedMgr.gameSpeed = 0;
                transform.position
                                = new Vector3(transform.position.x, 0, transform.position.z);
                if (hitCurTime > m_CurrentClipInfo[0].clip.length)
                {
                    hitCurTime = 0;
                    isHit = false;
                    
                    jumpState = JUMPSTATE.IDLE;
                    gameSpeedMgr.gameSpeed = 8f;
                    
                }
                break;
            default:
                break;
        }
        unityChanAnim.SetBool("ISJUMP", isJump);
        unityChanAnim.SetBool("ISSLIDE", isSlide);
        unityChanAnim.SetBool("ISHIT", isHit);

        if (isBooster == true && ui.qPanel.activeSelf == false)
        {
            Time.timeScale = 3f;
            boosterCurTime += Time.deltaTime;
            if (boosterCurTime > boosterCoolTime)
            {
                Time.timeScale = 1f;
                isBooster = false;
                boosterCnt = 0;
                boosterCurTime = 0;
                isGod = false;
            }
        }

        if (isDead == true)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
        }
    }

    public void Jump()
    {
        if(jumpCnt < jumpCntMax && (jumpState != JUMPSTATE.SLIDE) && isHit == false && (jumpState != JUMPSTATE.HIT))
        {
            jumpCnt++;
            jumpLimit += transform.position.y;
            jumpState = JUMPSTATE.JUMP;
        }
    }

    public void SlidingKeyDown()
    {
        slideBtnPress = true;
    }

    public void SlidingKeyUp()
    {
        slideBtnPress = false;
    }

    public void LeftKey()
    {
        if(isLeftRotate)
        {
            isPass = true;
        }
    }
    public void RightKey()
    {
        if(isRightRotate)
        {
            isPass = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && isGod == false)
        {
            playerHP -= 2;
            jumpState = JUMPSTATE.HIT;
            if (playerHP <= 0)
            {
                isDead = true;
            }
        }
        if(other.gameObject.name == "TopEnemy(Clone)" && isGod == false && jumpState!=JUMPSTATE.SLIDE)
        {
            playerHP -= 2;
            jumpState = JUMPSTATE.HIT;
            if (playerHP <= 0)
            {
                isDead = true;
            }
        }
        if (other.gameObject.tag == "Item" || other.gameObject.tag == "Coin" || other.gameObject.tag =="Heal" || other.gameObject.tag == "Booster")
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