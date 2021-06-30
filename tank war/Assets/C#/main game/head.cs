using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head : MonoBehaviour
{
    //public FixedJoystick joystick;
    public RectTransform handle;

    public float angle;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (CompareTag("redplayer"))
        {
            handle = GameObject.Find("red Handle 1").GetComponent<RectTransform>();
        }
        else if(CompareTag("blueplayer"))
        {
            handle = GameObject.Find("blue Handle 1").GetComponent<RectTransform>();
        }
    }

    void Update()
    {
        if(handle.anchoredPosition.x == 0 && handle.anchoredPosition.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            float angle = Mathf.Atan2(handle.anchoredPosition.y, handle.anchoredPosition.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        
    }

    
}

