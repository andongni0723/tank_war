using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;

    [Header("音效")]
    public AudioSource audiosource;
    public AudioClip fire;
    public AudioClip hit;
    public AudioClip run;

    [Header("物件")]
    public RectTransform redhandle;
    public RectTransform bluehandle;

    public Text redhp_T;
    public Text bluehp_T;
    public Text gameovertext_T;

    public GameObject red;
    public GameObject blue;

    public GameObject map01;
    public GameObject map02;

    public List<GameObject> redtank = new List<GameObject>();
    public List<GameObject> bluetank = new List<GameObject>();
    public GameObject redplayer;
    public GameObject blueplayer;

    public GameObject gameoverpaneel;

    [Header("角色選擇")]
    public GameObject GameObject;
    public RectTransform gameobject;
    public Image playerchangepanel;
    public Text changetext_T;
    public int changenum = 1;
    public Sprite newplayer_P;
    public List<Sprite> playerpng = new List<Sprite>();
    public Image playersee_I;
    public Button ok_B;
    

    [Header("變數")]
    public int redhp;
    public int bluehp;
    public bool isfinish;
    public int redplayerlistnum;
    public int blueplayerlistnum;
    public bool isok;

    
    private void Awake()
    {
        instance = this;

        switch (PlayerPrefs.GetString("map"))
        {
            case "map01":
                map01.SetActive(true);
                map02.SetActive(false);
                break;
            case "map02":
                map01.SetActive(false);
                map02.SetActive(true);
                break;
        }
    }

    void Start()
    {
        //playersee_I.sprite = newplayer_P;

        
    }

    
    void Update()
    {
        redhp_T.text = redhp.ToString();
        bluehp_T.text = bluehp.ToString();

        
        if (bluehp <= 0 || redhp <= 0) gameover();
    }

    //選角系統
    public void change(int num)
    {
        playersee_I.sprite = playerpng[num - 1];
        if (changenum == 1)
        {
            redplayerlistnum = num - 1;
        }
        else
        {
            blueplayerlistnum = num - 1;
        }
        
    }
    public void changeok()
    {
        if(changenum == 1)
        {
            playerchangepanel.color = new Color32(122, 152, 245, 255);
            changetext_T.color = new Color32(0, 16, 164, 255);
            gameobject.rotation = Quaternion.Euler(0, 0, 180);
            changenum = 2;

            playersee_I.sprite = newplayer_P;

        }
        else
        {
            this.GameObject.SetActive(false);
            Instantiate(redtank[redplayerlistnum], red.transform.position, red.transform.rotation);
            Instantiate(bluetank[blueplayerlistnum], blue.transform.position, blue.transform.rotation);

            move.instance.changemovepng();
            move2.instance.changemovepng();

            //speed tank
            if (redplayerlistnum == 0) redhp = 17;
            if (blueplayerlistnum == 0) bluehp = 17;
            //shoot tank
            if (redplayerlistnum == 1) redhp = 20;
            if (blueplayerlistnum == 1) bluehp = 20;
            //tank tank
            if (redplayerlistnum == 2) redhp = 25;
            if (blueplayerlistnum == 2) bluehp = 25;
            //bomb tank
            if (redplayerlistnum == 3) redhp = 20;
            if (blueplayerlistnum == 3) bluehp = 20;
            //landmine tank
            if (redplayerlistnum == 4) redhp = 20;
            if (blueplayerlistnum == 4) bluehp = 20;

            isok = true;
        }
    }
    //public void redtoblue(int num)
    //{
    //    if(num == 1)
    //    {

    //    }
    //    else
    //    {

    //    }
    //}

    //遊戲結束
    public void gameover()
    {
        
        gameoverpaneel.SetActive(true);

        if(redhp <= 0 && isfinish == false)
        {
            gameovertext_T.text = "藍隊勝利";
            gameovertext_T.color = Color.blue;
            isfinish = true;
        }
        if(bluehp <= 0 && isfinish == false)
        {
            gameovertext_T.text = "紅隊勝利";
            gameovertext_T.color = Color.red;
            isfinish = true;
        }       
    }

    public void again()
    {
        SceneManager.LoadScene("maingame");
    }

    //音效系統
    public void fireout()
    {
        audiosource.PlayOneShot(fire);
    }
    public void runout()
    {
        audiosource.PlayOneShot(run);
    }
    public void onhit()
    {
        audiosource.PlayOneShot(hit);

    }

    public void home()
    {
        SceneManager.LoadScene("start");
    }
}
