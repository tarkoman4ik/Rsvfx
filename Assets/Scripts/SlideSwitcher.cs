using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SlideSwitcher : MonoBehaviour
{
    public float time = 10.0f,duration=1.0f,timeLeft=30.0f;
    public bool NextSceneUpdate = false;
    private void Start()
    {
        DOTween.Sequence()
            .AppendInterval(time)
            .Append(transform.DOMove(endValue: new Vector3(x: -38, y: 0.77f, z: 0), duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMove(endValue: new Vector3(x: -76, y: 0.77f, z: 0), duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMove(endValue: new Vector3(x: -114, y: 0.77f, z: 0), duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMove(endValue: new Vector3(x: -152, y: 0.77f, z: 0), duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMove(endValue: new Vector3(x: -190, y: 0.77f, z: 0), duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMove(endValue: new Vector3(x: -228, y: 0.77f, z: 0), duration: duration))
            .AppendInterval(time)
            .SetLoops(-1);
    }
    private void Update()
    {
        if (NextSceneUpdate)
        {
            NextScene();
            NextSceneUpdate = false;
        }
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
            NextSceneUpdate = true;
    }
    public void NextScene()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        if (index == 3)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(index+1);
    }
}
