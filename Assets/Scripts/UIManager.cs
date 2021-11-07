using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Slider playerHP;
    public Text itemCounter;
    public PlayerController playerController;
    public Slider boosterGage;
    public GameObject popUpPanel;
    public Toggle pauseBtn;
    public Slider bgmSlider;
    public AudioSource bgm;
    public GameObject popUpEnd;
    public GameSpeedMgr speedMgr;
    public float curTime = 0f;
    public int ggambakCnt = 0;
    public float boosterCurtime = 0f;
    public GameObject qPanel;
    public int qPanelCnt = 0;
    public float effectVol = 1f;
    public Slider effectVolSlider;
    public bool isMute;
    void Start()
    {
        Time.timeScale = 1f;
        playerHP = GameObject.Find("playerHP").GetComponent<Slider>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        itemCounter = GameObject.Find("itemCounter").GetComponent<Text>();
        boosterGage = GameObject.Find("BoosterGage").GetComponent<Slider>();
        speedMgr = GameObject.Find("GameSpeedMgr").GetComponent<GameSpeedMgr>();
        qPanelCnt = 0;
        boosterCurtime = 0f;
        qPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerHP.value = (float)(playerController.playerHP) / (float)(playerController.playerMaxHp);
        //Debug.Log((float)(playerController.playerHP) / (float)(playerController.playerMaxHp));
        itemCounter.text = playerController.itemCnt + "°³";

        if(isMute == false)
        {
            effectVol = effectVolSlider.value;
        }
        
        
        if(playerController.isBooster)
        {
            curTime += Time.deltaTime;
            if(curTime > 0.3f)
            {
                if(ggambakCnt == 0)
                {
                    boosterGage.value = (playerController.boosterCoolTime - playerController.boosterCurTime) / (playerController.boosterCoolTime);
                    ggambakCnt = 1;
                }
                else if(ggambakCnt == 1)
                {
                    boosterGage.value = 0;
                    ggambakCnt = 0;
                }
                curTime = 0;
            }
        }
        else
        {
            boosterGage.value = (float)(playerController.boosterCnt) / (float)(playerController.boosterMax);
        }
        bgm.volume = bgmSlider.value;
    }

    public void PopUpPanelOnOff()
    {
        if(pauseBtn.isOn == false)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0;
        }
        popUpPanel.SetActive(pauseBtn.isOn);
    }
    

    public void GoMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("01_Intro");
    }
    public void GameEnd()
    {
        Application.Quit();
    }
    public void OnQPanel()
    {
        if(pauseBtn.isOn == false)
        {
            qPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void CloseQPanel()
    {
        qPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void MuteBtn()
    {
        Debug.Log(effectVolSlider.value.ToString());
        effectVol = 0f;
        isMute = true;
    }
    public void UnMutebtn()
    {
        effectVol = effectVolSlider.value;
        isMute = false;
    }
}
