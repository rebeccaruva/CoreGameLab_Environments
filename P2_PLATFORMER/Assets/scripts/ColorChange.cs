using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private GameObject sun; 
    float r, g, b;
    //    [SerializeField]
    //    Gradient gradient1;
    //    [SerializeField]
    //    float colorDuration;
    //    float time = 0f;
    //    float value;

    //void Start()
    //{
    //    value = Mathf.Lerp(0f, 1f, time);
    //    sun = GameObject.Find("Sun"); 
    //}

    //    void Update()
    //    {

    //        if (time == colorDuration)
    //        {
    //            value = Mathf.Lerp(1f, 0f, time);
    //        }
    //        else         {
    //            value = Mathf.Lerp(0f, 1f, time);
    //        }

    //        time += Time.deltaTime / colorDuration;
    //        Color color = gradient1.Evaluate(value);
    //        Camera.main.backgroundColor = color;
    //    }
    //}
    public Color lerpedColor = new Color(0f, 0.1f, 0.3f);
    void Update()
    {
        lerpedColor = Color.Lerp(new Color(0f, 0.1f, 0.3f), new Color(0.3f, 0.7f, 0.94f), Mathf.PingPong(Time.time, 15));
        Camera.main.backgroundColor = lerpedColor;
    }
}
