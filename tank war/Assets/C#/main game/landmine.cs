using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landmine : MonoBehaviour
{
    
    public GameObject bomb;
    public GameObject fixingnow;
    public int hp = 3;
    public float fixingtime;
    public float timer;
    public bool isfixing;
    public int teamnum;//red is 0,blue is 1.
    PolygonCollider2D pc;

    private void Start()
    {
        
    }
    private void Awake()
    {
        pc = GetComponent<PolygonCollider2D>();
        isfixing = true;
        pc.enabled = false;
        fixingnow.SetActive(true);
    }
    private void Update()
    {
        
        timer += Time.deltaTime;

        if (timer >= fixingtime) 
        {
            isfixing = false;
            pc.enabled = true;
            fixingnow.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isfixing)
        {
            if (teamnum == 0)
            {
                
                if (other.transform.CompareTag("blueplayer"))
                {
                    hit();
                }
                if (other.transform.CompareTag("redplayer"))
                {
                    Instantiate(bomb, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
                    Destroy(gameObject);
                }
            }
            else if (teamnum == 1)
            {
                if (other.transform.CompareTag("redplayer"))
                {
                    hit();
                }
                if (other.transform.CompareTag("blueplayer"))
                {
                    Instantiate(bomb, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
                    Destroy(gameObject);
                }
            }

            if (other.transform.CompareTag("blue") || other.transform.CompareTag("red"))
            {
                hp--;

                if (hp == 0)
                {
                    Destroy(gameObject);
                }
            }
            
            
        }    
    }

    public void hit()
    {
        if(teamnum == 0)
        {
            gamemanager.instance.bluehp--;
        }
        else
        {
            gamemanager.instance.redhp--;
        }

        gamemanager.instance.onhit();
        
        Instantiate(bomb, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        Destroy(gameObject);
    }
}
