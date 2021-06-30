using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombs : MonoBehaviour
{
    public float speed;

    public float timer;
    public float span;
    public bool canbomb;

    public GameObject prefab;

    public List<GameObject> dips = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, speed) * Time.deltaTime);


        timer += Time.deltaTime;
        if (timer >= span) 
        {
            shoot();
            Destroy(gameObject);              
        } 
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        shoot();
        Destroy(gameObject);
    }

    public void shoot()
    {
        Instantiate(prefab, dips[0].transform.position, dips[0].transform.rotation);
        Instantiate(prefab, dips[1].transform.position, dips[1].transform.rotation);
        Instantiate(prefab, dips[2].transform.position, dips[2].transform.rotation);
        Instantiate(prefab, dips[3].transform.position, dips[3].transform.rotation);
        Instantiate(prefab, dips[4].transform.position, dips[4].transform.rotation);
        Instantiate(prefab, dips[5].transform.position, dips[5].transform.rotation);
        Instantiate(prefab, dips[6].transform.position, dips[6].transform.rotation);
        Instantiate(prefab, dips[7].transform.position, dips[7].transform.rotation);
    }
}
