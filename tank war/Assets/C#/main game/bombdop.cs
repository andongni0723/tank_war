using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombdop : MonoBehaviour
{
    public bombs bombs;

    public GameObject buttet;
    public float timer;
    public float span;

    void Start()
    {
        
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= span)
        {
            Instantiate(buttet, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if(bombs.canbomb)
        {
            //(buttet, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
