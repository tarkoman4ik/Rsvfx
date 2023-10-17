using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SlideSwitcherVertical : MonoBehaviour
{
    public float time = 20.0f, duration = 1.0f;
    public GameObject video1, video2,video3;
    private VideoPlayer videoPlayer1, videoPlayer2,videoPlayer3;

    private void Start()
    {
        DOTween.Sequence()
            .AppendInterval(time)
            .Append(transform.DOMoveY(endValue: 36.2f, duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMoveY(endValue: 71.2f, duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMoveY(endValue: 106.2f, duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMoveY(endValue: 141.2f, duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMoveY(endValue: 176.2f, duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMoveY(endValue: 211.2f, duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMoveY(endValue: 246.2f, duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMoveY(endValue: 281.2f, duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMoveY(endValue: 316.2f, duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMoveY(endValue: 351.2f, duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMoveY(endValue: 386.2f, duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMoveY(endValue: 421.2f, duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMoveY(endValue: 456.2f, duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMoveY(endValue: 491.2f, duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMoveY(endValue: 1.2f,duration:duration))
            .SetLoops(-1);
    }
}
