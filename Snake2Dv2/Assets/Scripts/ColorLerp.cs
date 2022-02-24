using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    [SerializeField] private Camera Maincamera;
    [SerializeField] Color[] color;
    [SerializeField] float lerpTime;
    [SerializeField] int index;
    [SerializeField] float changer;
    private void Start()
    {
        Maincamera = GetComponent<Camera>();
    }
    private void Update()
    {
        Maincamera.backgroundColor = Color.Lerp(Maincamera.backgroundColor,color[index],lerpTime*Time.deltaTime);
        changer = Mathf.Lerp(changer,1f,lerpTime*Time.deltaTime);
        if (changer>0.9f)
        {
            changer = 0;
            index += 1;
            if (index>=color.Length)
            {
                index = 0;
            }
        }
    }
}
