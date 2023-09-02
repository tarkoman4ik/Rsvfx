using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SlideSwitcher : MonoBehaviour
{
    public float time = 3.0f,duration=1.0f,timeLeft=30.0f;
    public bool NextSceneUpdate = false;
    public GameObject video1,video2;
    private VideoPlayer videoPlayer1,videoPlayer2;
    public float timeVideo = 83.0f;
    private bool first = false, second = false;
    private void Start()
    {
        videoPlayer1 = video1.GetComponent<VideoPlayer>();
        videoPlayer2 = video2.GetComponent<VideoPlayer>();
        videoPlayer1.Pause();
        videoPlayer2.Pause();
        DOTween.Sequence()
            .AppendInterval(time)
            .Append(transform.DOMove(endValue: new Vector3(x: -38, y: 0.77f, z: 0), duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMove(endValue: new Vector3(x: -76, y: 0.77f, z: 0), duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMove(endValue: new Vector3(x: -114, y: 0.77f, z: 0), duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMove(endValue: new Vector3(x: -152, y: 0.77f, z: 0), duration: duration))
            .AppendInterval(time+5.0f)
            .Append(transform.DOMove(endValue: new Vector3(x: -190, y: 0.77f, z: 0), duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMove(endValue: new Vector3(x: -228, y: 0.77f, z: 0), duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMove(endValue: new Vector3(x: -266, y: 0.77f, z: 0), duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMove(endValue: new Vector3(x: -304, y: 0.77f, z: 0), duration: duration))
            .AppendInterval(time)
            .Append(transform.DOMove(endValue: new Vector3(x: -342, y: 0.77f, z: 0), duration: duration))
            .AppendInterval(time+87.0f)
            .Append(transform.DOMove(endValue: new Vector3(x: 0, y: 0.77f, z: 0), duration: duration))
            .SetLoops(-1);
    }
    private void Update()
    {
        timeVideo-= Time.deltaTime;
        if (timeVideo < 0 && first == false&&second==false)
        {
            timeVideo += 25.0f;
            first = true;
            videoPlayer1.Play();
        }
        if (timeVideo<0&&first==true&&second==false)
        {
            timeVideo += 85.0f;
            first = false;
            second = true;
        }
        if (timeVideo < 0 && second == true)
        {
            videoPlayer2.Play();
            second = false;
            timeVideo += 192.0f;
        }
        //if (NextSceneUpdate)
        //{
        //    NextScene();
        //    NextSceneUpdate = false;
        //}
        //timeLeft -= Time.deltaTime;
        //if (timeLeft < 0)
        //    NextSceneUpdate = true;
    }
    public void NextScene()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        if (index == 1)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(index + 1);
    }
}
