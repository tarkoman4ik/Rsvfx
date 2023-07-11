using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlideSwitcher : MonoBehaviour
{
    public float time = 10.0f,duration=1.0f;
    private void Start()
    {
        DOTween.Sequence()
            .AppendInterval(time)
            .Append(transform.DOMove(endValue: new Vector3(x: -38, y: 0.77f, z: 0), duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMove(endValue: new Vector3(x: 0, y: 0.77f, z: 0), duration: duration))
            .SetLoops(-1);
    }
}
