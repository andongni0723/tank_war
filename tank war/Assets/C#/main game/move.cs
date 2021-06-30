using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    [Header("物件")]
    public GameObject player;

    Button button;
    public GameObject cdgameobject;
    Image image;
    public Image cd_I;
    public GameObject cdtext;
    public Text cdtext_T;

    public GameObject hasnumobj;
    public Text hasnnumobj_T;
    public GameObject bombbulletdip;
    public GameObject landmine;
    public GameObject piovt;
    public GameObject point;
    public GameObject thetank;
    public GameObject slider;
    public Slider thetankhp;
    public int thetankhp_int;

    public static move instance;

    public List<Sprite> moves = new List<Sprite>();

    [Header("變數")]
    public bool isopen;   
    public bool colding;
    
    public int teamlistnum;
    private float timer;
    public int cd;
    public float cdtime;
    public int maxhavenum;
    public int hasnum;

    //[Header("護盾")]

    private void Awake()
    {
        instance = this;       
    }

    void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();    
        //if (teamlistnum == 2) thetank = GameObject.Find("redtank");
    }
    
    public void toopen()
    {
        if (hasnum > 0)
        {
            isopen = true;
            hasnum--;
            //button.interactable = false;
            //if(hasnum == 0) colding = true;
        }  
    }

    public void changemovepng()
    {
        //changemovepng  
        teamlistnum = gamemanager.instance.redplayerlistnum;
        image.sprite = moves[teamlistnum];
        cd_I.sprite = moves[teamlistnum];            
        
        
        //gameobjects of player
        switch (gamemanager.instance.redplayerlistnum)
        {
            case 0:
                cd = 10;
                maxhavenum = 1;

                player = GameObject.Find("red body");
                break;
            case 1:
                cd = 15;
                maxhavenum = 1;

                player = GameObject.Find("red body(shoot)");
                break;
            case 2:
                cd = 10;
                maxhavenum = 1;

                player = GameObject.Find("red body(tank)");
                piovt = GameObject.Find("redpivot");
                thetank = GameObject.Find("redtank");
                thetank.SetActive(false);
                break;
            case 3:
                cd = 5;
                maxhavenum = 1;
                player = GameObject.Find("red body(bomb)");
                bombbulletdip = GameObject.Find("red bomb bullet dip");
                break;
            case 4:
                cd = 5;
                maxhavenum = 5;
                hasnum = 5;

                player = GameObject.Find("red body(landmine)"); 
                point = GameObject.Find("redpoint");
                hasnumobj.SetActive(true);
                break;
        }

        cdtime = cd;
    }
    
    void Update()
    {
        hasnnumobj_T.text = hasnum.ToString();

        if (teamlistnum == 1 && isopen)
        {
            GameObject.Find("red bullet dip (move)").GetComponent<bulletgenator>().enabled = true;
            float span = 2;
            timer += Time.deltaTime;
            if (timer >= span)
            {
                GameObject.Find("red bullet dip (move)").GetComponent<bulletgenator>().enabled = false;
                timer = 0;
                isopen = false;
            }
        }

        if(teamlistnum == 2 && isopen)
        {
            //thetank = GameObject.Find("redtank");
            thetankhp.value = 1;
            thetank.SetActive(true);
            slider.SetActive(true);
            thetankhp.value = 1;
            thetankhp_int = 5;
            isopen = false;
        }

        if(teamlistnum == 4 && isopen)
        {
            Instantiate(landmine, point.transform.position, Quaternion.identity);
            isopen = false;
        }

        if (gamemanager.instance.isok)
        {
            if (hasnum < maxhavenum)
            {
                
                colding = true;
                
                cdtext.SetActive(true);
                

                
                
                //Debug.Log("ff");
                cdtime -= Time.deltaTime;
                cdtext_T.text = cdtime.ToString("0");
                cd_I.fillAmount = (cdtime) / cd;

                if (cdtime <= 0)
                {
                    //button.interactable = true;
                    hasnum++;
                    cdtext.SetActive(false);
                    colding = false;
                    cdtime = cd;
                    cd_I.fillAmount = 0;
                }
            }
            //
            //cdtime -= Time.deltaTime;
            
        }
        
    }

    public void hurttank()
    {
        thetankhp_int -= 1;
        thetankhp.value = thetankhp_int * 0.2f;
    }
    public void tankdied()
    {
        thetankhp_int = 0;
        thetankhp.value = 0;

        thetank.SetActive(false);
        slider.SetActive(false);
    }
}
