using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletgenator : MonoBehaviour
{
    public GameObject prefab;
    public Transform pivot;
    public RectTransform handle;

    public float timer;
    public float span;

    void Start()
    {
        if (CompareTag("redplayer"))
        {
            handle = GameObject.Find("red Handle 1").GetComponent<RectTransform>();
            
        }
        else if (CompareTag("blueplayer"))
        {
            handle = GameObject.Find("blue Handle 1").GetComponent<RectTransform>();
        }
    }

    void Update()
    {
        transform.rotation = pivot.rotation;
        
        timer += Time.deltaTime;

        if(handle.anchoredPosition != new Vector2(0, 0))
        {
            if (timer >= span)
            {
                timer = 0;
                Instantiate(prefab, transform.position, pivot.rotation);
                gamemanager.instance.fireout();

                if (CompareTag("redplayer") && gamemanager.instance.redplayerlistnum == 3)
                {
                    //gameObject.SetActive(false);
                }
                else if(CompareTag("blueplayer") && gamemanager.instance.blueplayerlistnum == 3)
                {
                    //gameObject.SetActive(false);
                }
            }
        }
    }  
}
