using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Example_Tween04_Text : MonoBehaviour
{
    public string msg;
    public Text targetText;
    public Ease ease;
    public LoopType loopType;
    void Start()
    {
        targetText.DOText(msg, 10).SetLoops(-1, loopType).SetEase(ease);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
