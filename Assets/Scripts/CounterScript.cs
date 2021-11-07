using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour
{
    public float curTime = 0f;
    public float coolTime = 1f;
    public int cnt = 0;
    public Text cntTxt;
    public GameObject cntText;
    public GameObject popup;
    // Start is called before the first frame update
    void Start()
    {
        cnt = 3;
        cntTxt.text = cnt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if(curTime > coolTime && cnt >= 0)
        {
            curTime = 0f;
            cnt--;
            if(cnt >0)
            {
                cntTxt.text = cnt.ToString();
            }
            else
            {
                cntTxt.text = "Go!";
            }
        }
        else if(cnt < 0)
        {
            cntTxt.text = "";
        }
    }
    public void CntOnOff()
    {
        if(cntTxt.isActiveAndEnabled == true)
        {
            cntTxt.enabled = false;
        }
        else
        {
            cntTxt.enabled = true;
        }
    }
}
