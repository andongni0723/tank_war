using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombgenator : MonoBehaviour
{
    public GameObject prefab;
    

    // Update is called once per frame
    void Update()
    {
        if(CompareTag("redplayer") && gamemanager.instance.redplayerlistnum == 3 && move.instance.isopen)
        {
            Instantiate(prefab, transform.position, transform.rotation);
            move.instance.isopen = false;
        }
        else if(CompareTag("blueplayer") && gamemanager.instance.blueplayerlistnum == 3 && move2.instance.isopen)
        {
            Instantiate(prefab, transform.position, transform.rotation);
            move2.instance.isopen = false;
        }
    }
}
