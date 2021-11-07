using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedMgr : MonoBehaviour
{
    public float gameSpeed = 8f;
    public bool isPause = false;
    public float curTime;
    public float coolTime = 10f;
    public float tempScale;
    public float maxGameSpeed = 16f;
    void Start()
    {
        tempScale = 1f;
        gameSpeed = 8f;
    }

    void Update()
    {
        curTime += Time.deltaTime;
        if(curTime > coolTime && gameSpeed < maxGameSpeed)
        {
            gameSpeed += 0.01f;
        }
    }

    public void PauseGame()
    {
        Debug.Log("Here!!!!!!!!!!");
    }
}
