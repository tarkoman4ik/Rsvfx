using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemTimeWidget : MonoBehaviour
{
    public GameObject TimeImage;
    private int hours, minutes;

    private void Update()
    {
        hours = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        if(System.DateTime.Now.Minute < 10)
        {
            TimeImage.GetComponent<Text>().text = hours + ":" + "0" + minutes;
        }
        else
        {
            TimeImage.GetComponent<Text>().text = hours + ":" + minutes;
        }
    }
}
