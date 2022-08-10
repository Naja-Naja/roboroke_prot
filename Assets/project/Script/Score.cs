using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    public robotmove Robotmove;
    public Text text;
    public int max;
    void Start()
    {
        IDisposable subscription_leftTeam = Robotmove.distance.Subscribe(x =>
        {
            if (x > max)
            {
                max = (int)x;
            }
            text.text = "”ò‹——£F"+((int)x).ToString()+"\nÅ‚‹L˜^F"+max.ToString();
            //ButtonFadeScale(leftTeamButton, x);
        });
    }
}
