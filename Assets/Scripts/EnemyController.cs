using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed = 0f;
    public GameObject[] effects;
    public GameSpeedMgr gameSpeedMgr;
    public PlayerController player;
    public AudioClip boosterAudio;
    public AudioClip healAudio;
    public AudioClip itemAudio;
    public AudioClip coinAudio;
    public AudioClip hitAudio;
    public UIManager uiMgr;
    void Start()
    {
        gameSpeedMgr = GameObject.Find("GameSpeedMgr").GetComponent<GameSpeedMgr>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        uiMgr = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void Update()
    {
        
        enemySpeed = 0f;
        transform.Translate(-enemySpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name + " :::: 에 맞았다!!!!!!!!!!!!!!!!!!!");
        if(other.gameObject.tag == "Player" && gameObject.tag != "TopEnemy")
        {
            switch (gameObject.tag)
            {
                case "Item":
                    Instantiate(effects[0], transform.position, transform.rotation);
                    AudioSource.PlayClipAtPoint(itemAudio, transform.position, uiMgr.effectVol);

                    break;
                case "Booster":
                    Instantiate(effects[1], transform.position, transform.rotation);
                    AudioSource.PlayClipAtPoint(boosterAudio, transform.position, uiMgr.effectVol);

                    break;
                case "Coin":
                    Instantiate(effects[2], transform.position, transform.rotation);
                    AudioSource.PlayClipAtPoint(coinAudio, transform.position, uiMgr.effectVol);

                    break;
                case "Heal":
                    Instantiate(effects[3], transform.position, transform.rotation);
                    AudioSource.PlayClipAtPoint(healAudio, transform.position, uiMgr.effectVol);

                    if (player.playerHP < 10)
                    {
                        player.playerHP++;
                    }
                    break;
                default:
                    Instantiate(effects[4], transform.position, transform.rotation);
                    AudioSource.PlayClipAtPoint(hitAudio, transform.position, uiMgr.effectVol);

                    break;
            }
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Player" && gameObject.tag == "TopEnemy")
        {
            if(player.jumpState != PlayerController.JUMPSTATE.SLIDE)
            {
                Instantiate(effects[4], transform.position, transform.rotation);
                AudioSource.PlayClipAtPoint(hitAudio, transform.position, uiMgr.effectVol);
                Destroy(gameObject);
            }
        }
        
    }
}
