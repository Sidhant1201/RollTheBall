using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{
    public Color[] color;
    [Range(0, 1)] public float lerptime;
    int colorindex = 0;
    private MeshRenderer rend;
    float time;

    private void Start()
    {
        rend = GetComponent<MeshRenderer>();
        
    }

    private void Update()
    {
        rend.material.color = Color.Lerp(rend.material.color, color[colorindex], lerptime * Time.deltaTime);
        time = Mathf.Lerp(time, 1f, lerptime * Time.deltaTime);
        if (time > 0.9f)
        {
            time = 0;
            colorindex++;
            colorindex = (colorindex >= color.Length) ? 0 : colorindex;
        }

        //rotating coin

        rend.transform.Rotate(new Vector3(2, 5, 10) * Time.deltaTime);
    }
}
