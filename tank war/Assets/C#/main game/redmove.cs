using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redmove : MonoBehaviour
{
    

    public float xvelocity;
    public float yvelocity;
    public float speed;

    public int hp;

    public bool isrun;

    Rigidbody2D rb;
    public RectTransform handle;

    public float timer;
    public float span = 5;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (CompareTag("redplayer"))
        {
            handle = GameObject.Find("red Handle").GetComponent<RectTransform>();
        }
        else if(CompareTag("blueplayer"))
        {
            handle = GameObject.Find("blue Handle").GetComponent<RectTransform>();
        }
    }

    void Update()
    {

        movement();

        if (CompareTag("redplayer") && gamemanager.instance.redplayerlistnum == 0 && move.instance.isopen) 
        {
            speed = 5;

            timer += Time.deltaTime;
            if(timer >= span)
            {
                timer = 0;
                move.instance.isopen = false;
                speed = 1.5f;
            }
        }
        else if (CompareTag("blueplayer") && gamemanager.instance.blueplayerlistnum == 0 && move2.instance.isopen)
        {
            speed = 5;

            timer += Time.deltaTime;
            if (timer >= span)
            {
                timer = 0;
                move2.instance.isopen = false;
                speed = 1.5f;
            }
        }
       
    }

    public void movement()
    {        
        if (handle.anchoredPosition.x == 0 && handle.anchoredPosition.y == 0)
        {
            if (isrun)
            {
                gamemanager.instance.audiosource.Stop();
                isrun = false;
            }

            transform.rotation = Quaternion.Euler(0, 0, 0);            
        }
        else
        {
            if (!isrun)
            {
                gamemanager.instance.runout();
                isrun = true;
            }
            

            float angle = Mathf.Atan2(handle.anchoredPosition.y, handle.anchoredPosition.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            transform.Translate(0, speed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CompareTag("redplayer"))
        {
            
        }
    }
}
