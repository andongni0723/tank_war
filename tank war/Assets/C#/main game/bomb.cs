using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public List<Sprite> bombJPG = new List<Sprite>();

    SpriteRenderer sr;

    public float timer;
    public float span;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        sr.sprite = bombJPG[Random.Range(0, bombJPG.Count)];
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= span)
        {
            timer = 0;
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
