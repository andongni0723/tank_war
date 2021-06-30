using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;

    public GameObject bomb;

    public string teamnum;
    public float speed;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        //rb.AddRelativeForce(new Vector3(0, speed * Time.deltaTime, 0));
        //rb.velocity = new Vector2(0, speed);
        //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y * speed * Time.deltaTime, 0);
        transform.Translate(new Vector2(0, speed) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {      
        if(teamnum == "red")
        {
            if (other.transform.CompareTag("blueplayer"))
            {
                gamemanager.instance.bluehp--;

                gamemanager.instance.onhit();

                cemerashake.instance.isshakeCamera = true;

                Destroy(gameObject);
            }

            if (other.transform.CompareTag("blue") || other.transform.CompareTag("redplayer") || other.transform.CompareTag("redlm")|| other.transform.CompareTag("bluelm"))
            {
                Destroy(gameObject);
            }
            
        }
        else
        {
            if (other.transform.CompareTag("redplayer"))
            {
                gamemanager.instance.redhp--;
                gamemanager.instance.onhit();

                cemerashake.instance.isshakeCamera = true;
                Destroy(gameObject);
            }

            if (other.transform.CompareTag("red") || other.transform.CompareTag("blueplayer") || other.transform.CompareTag("redlm") || other.transform.CompareTag("bluelm"))
            {
                Destroy(gameObject);
            }
        }

        if (other.transform.CompareTag("collision"))
        {
            Destroy(gameObject);
        }

        

        Instantiate(bomb, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (teamnum == "red")
        {           

            if (other.transform.CompareTag("bluetanktank"))
            {
                if (move2.instance.thetankhp_int == 0)
                {
                    move2.instance.tankdied();
                }
                else
                {
                    move2.instance.hurttank();
                }

                Destroy(gameObject);
            }
           
        }
        else
        {         
            if (other.transform.CompareTag("redtanktank"))
            {
                if (move.instance.thetankhp_int == 0)
                {
                    move.instance.tankdied();
                }
                else
                {
                    move.instance.hurttank();                   
                }

                Destroy(gameObject);
            }
        }
    }
}
