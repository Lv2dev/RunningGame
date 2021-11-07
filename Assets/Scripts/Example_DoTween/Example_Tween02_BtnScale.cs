using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Example_Tween02_BtnScale : MonoBehaviour
{
    public Ease tweenEase;
    public LoopType loopType;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnScale()
    {
        transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f).SetEase(tweenEase).SetLoops(1, loopType).OnComplete(()=> {
            transform.localScale = new Vector3(1, 1, 1);
        });
    }
}
