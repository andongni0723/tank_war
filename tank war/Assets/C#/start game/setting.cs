using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class setting : MonoBehaviour
{
    [Header("物件")]
    public Text mapname_T;
    public GameObject errorpanel;
    public GameObject readingpanel;
    public Toggle nosee_TG;

    [Header("主頁")]
    public GameObject store;
    public GameObject tank;
    public GameObject activity;
    public GameObject about;

    [Header("角色畫布")]
    public Image tankimage_I;
    public Text tankname_T;
    public Image move_I;
    public Text smallmove_T;
    public Text bigmove_T;
    public Text tanksay_T;


    [Header("地圖")]
    public Image map_I;
    public Toggle map01_TG;
    public Toggle map02_TG;

    public List<Sprite> mapimages = new List<Sprite>();

    [Header("變數")]
    public bool map;

    [Header("角色png")]
    public List<Sprite> tankimages = new List<Sprite>();
    public List<Sprite> smoveimages = new List<Sprite>();
    

    
    void Awake()
    {
        PlayerPrefs.SetString("map", "map01");

        //公告顯示
        if (PlayerPrefs.GetInt("nosee") != 0 && PlayerPrefs.GetInt("nosee") != 1)
        {
            PlayerPrefs.SetInt("nosee", 1);
        }

        if(PlayerPrefs.GetInt("nosee") == 0)
        {
            nosee_TG.isOn = true;
            readingpanel.SetActive(false);
        }
        else
        {
            nosee_TG.isOn = false;
            readingpanel.SetActive(true);
        }
    }
    
    //andongni game 網址
    public void URL()
    {
        Application.OpenURL("http://sites.google.com/view/andongni");
    }

    
    //角色系統
    public void player(Sprite sprite,string playername,Sprite playermovepng, string smove ,string bmove ,string say)
    {
        tankimage_I.sprite = sprite;
        tankname_T.text = playername;
        move_I.sprite = playermovepng;
        smallmove_T.text = smove;
        bigmove_T.text = bmove;
        tanksay_T.text = say;
    }
    public void loadplayer(int tanknum)
    {
        //角色介紹
        switch (tanknum)
        {
            case 1:
                player(tankimages[0], "機動坦克", smoveimages[0], "優點:移速增加<color=#07A600>0.35</color>\r\n缺點:生命值減少<color=#FF0000>3</color>", "大招:飛毛腿\r\n效果:移速增加<color=#07A600>1.75</color>，持續5秒\r\n冷卻:10秒", "推薦在對方角色是爆破坦克時使用，可以在開啟加速時躲避他的榴彈。");
                break;
            case 2:
                player(tankimages[1], "爆射坦克", smoveimages[1], "優點:可一次發射<color=#07A600>2</color>發子彈\r\n缺點:移動速度減少<color=#FF0000>0.5</color>", "大招:大爆射\r\n效果:射擊速度設為<color=#07A600>0.25</color>秒/顆，持續2秒\r\n冷卻:15秒", "推薦在對方角色是守護坦克時使用，可以在開啟大招時打他盾牌。");
                break;
            case 3:
                player(tankimages[2], "守護坦克", smoveimages[2], "優點:生命值增加<color=#07A600>5</color>\r\n缺點:射擊速度設為<color=#FF0000>0.75</color>秒/顆", "大招:守護\r\n效果:創造一個可以抵擋<color=#07A600>5</color>點傷害的盾牌(盾牌生命最大上限為5)\r\n冷卻:10秒", "推薦在對方角色是爆破坦克時使用，可以在他開啟大招時用盾牌擋流彈。");
                break;
            case 4:
                player(tankimages[3], "爆破坦克", smoveimages[3], "優點:射擊速度設為<color=#07A600>0.33</color>秒/顆\r\n缺點:移動速度減少<color=#FF0000>0.5</color>", "大招:手榴彈\r\n效果:發射一個面朝射擊方向的手榴彈，飛行一秒或撞到物體時爆炸，爆炸時發射8發子彈面朝不同方向，每一個子彈造成<color=#07A600>1</color>點傷害\r\n冷卻:5秒", "推薦在對方角色是機動坦克時使用，可以在開啟大招時用流彈打他。");
                break;
            case 5:
                player(tankimages[4], "地雷坦克", smoveimages[4], "優點:移速增加<color=#07A600>0.25</color>\r\n缺點:<color=#07A600>沒有缺點</color>", "大招:沒有電腦，也能玩踩地雷\r\n效果:安裝2秒後(安裝時踩到不會受傷，但會損壞)，放置一個地雷(生命:3)在地面上，爆炸造成<color=#07A600>1</color>點傷害，己方踩到不會受傷\r\n冷卻:5秒，可存放<color=#07A600>5</color>個", "推薦在對方角色是機動坦克時使用，地雷可以在他開啟加速時不經意的炸到他。");
                break;
        }
    }
    
    //遊戲開始時準備
    public void canstart()
    {
        if (map)
        {
            SceneManager.LoadScene("maingame");
        }
        else
        {
            errorpanel.SetActive(true);
        }
    }
    public void mapisok()
    {
        if (map01_TG.isOn)
        {
            mapname_T.text = "經典";
            map_I.sprite = mapimages[0];
            map = true;
            PlayerPrefs.SetString("map", "map01");
        }
        if (map02_TG.isOn)
        {
            mapname_T.text = "戰域";
            map_I.sprite = mapimages[1];
            map = true;
            PlayerPrefs.SetString("map", "map02");
        }
    }

    //公告
    public void savepaneltoogle()
    {

        if (nosee_TG.isOn)
        {
            PlayerPrefs.SetInt("nosee", 0);
        }
        else if(nosee_TG.isOn == false)
        {
            PlayerPrefs.SetInt("nosee", 1);
        }
    }

    //下列按鈕
    public void allclose()
    {
        store.SetActive(false);
        tank.SetActive(false);
        activity.SetActive(false);
        about.SetActive(false);
    }

    //離開
    public void quit()
    {
        Application.Quit();
    }
}
