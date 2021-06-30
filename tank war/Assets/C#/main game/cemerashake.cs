using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cemerashake : MonoBehaviour
{
    public static cemerashake instance;

    float before;
    public float shakeTime ;
    public  float fps ;
    public  float frameTime ;
    public  float shakeDelta;
    public Camera cam;
    public bool isshakeCamera = false;
    // Use this for initialization

    private void Awake()
    {
        instance = this;
    }

    
    void Start()
    {
        before = shakeTime;
        //shakeTime = 2.0f;
        //fps = 20.0f;
        //frameTime = 0.03f;
        //shakeDelta = 0.005f;
        // isshakeCamera=true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isshakeCamera)
        {
            if (shakeTime > 0)
            {
                shakeTime -= Time.deltaTime;
                if (shakeTime <= 0)
                {
                    cam.rect = new Rect(0.0f, 0.0f, 10.0f, 10.0f);
                    isshakeCamera = false;
                    shakeTime = before;
                    fps = 20.0f;
                    frameTime = 0.03f;
                    shakeDelta = 0.005f;
                }
                else
                {
                    frameTime += Time.deltaTime;

                    if (frameTime > 1.0 / fps)
                    {
                        frameTime = 0;
                        cam.rect = new Rect(shakeDelta * (-1.0f + 2.0f * Random.value), shakeDelta * (-1.0f + 2.0f * Random.value), 1.0f, 1.0f);
                    }
                }
            }
        }
    }
}
