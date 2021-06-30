using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class setting : MonoBehaviour
{
    [Header("����")]
    public Text mapname_T;
    public GameObject errorpanel;
    public GameObject readingpanel;
    public Toggle nosee_TG;

    [Header("�D��")]
    public GameObject store;
    public GameObject tank;
    public GameObject activity;
    public GameObject about;

    [Header("����e��")]
    public Image tankimage_I;
    public Text tankname_T;
    public Image move_I;
    public Text smallmove_T;
    public Text bigmove_T;
    public Text tanksay_T;


    [Header("�a��")]
    public Image map_I;
    public Toggle map01_TG;
    public Toggle map02_TG;

    public List<Sprite> mapimages = new List<Sprite>();

    [Header("�ܼ�")]
    public bool map;

    [Header("����png")]
    public List<Sprite> tankimages = new List<Sprite>();
    public List<Sprite> smoveimages = new List<Sprite>();
    

    
    void Awake()
    {
        PlayerPrefs.SetString("map", "map01");

        //���i���
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
    
    //andongni game ���}
    public void URL()
    {
        Application.OpenURL("http://sites.google.com/view/andongni");
    }

    
    //����t��
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
        //���⤶��
        switch (tanknum)
        {
            case 1:
                player(tankimages[0], "���ʩZ�J", smoveimages[0], "�u�I:���t�W�[<color=#07A600>0.35</color>\r\n���I:�ͩR�ȴ��<color=#FF0000>3</color>", "�j��:����L\r\n�ĪG:���t�W�[<color=#07A600>1.75</color>�A����5��\r\n�N�o:10��", "���˦b��訤��O�z�}�Z�J�ɨϥΡA�i�H�b�}�ҥ[�t�ɸ��ץL���h�u�C");
                break;
            case 2:
                player(tankimages[1], "�z�g�Z�J", smoveimages[1], "�u�I:�i�@���o�g<color=#07A600>2</color>�o�l�u\r\n���I:���ʳt�״��<color=#FF0000>0.5</color>", "�j��:�j�z�g\r\n�ĪG:�g���t�׳]��<color=#07A600>0.25</color>��/���A����2��\r\n�N�o:15��", "���˦b��訤��O�u�@�Z�J�ɨϥΡA�i�H�b�}�Ҥj�ۮɥ��L�޵P�C");
                break;
            case 3:
                player(tankimages[2], "�u�@�Z�J", smoveimages[2], "�u�I:�ͩR�ȼW�[<color=#07A600>5</color>\r\n���I:�g���t�׳]��<color=#FF0000>0.75</color>��/��", "�j��:�u�@\r\n�ĪG:�гy�@�ӥi�H���<color=#07A600>5</color>�I�ˮ`���޵P(�޵P�ͩR�̤j�W����5)\r\n�N�o:10��", "���˦b��訤��O�z�}�Z�J�ɨϥΡA�i�H�b�L�}�Ҥj�ۮɥά޵P�׬y�u�C");
                break;
            case 4:
                player(tankimages[3], "�z�}�Z�J", smoveimages[3], "�u�I:�g���t�׳]��<color=#07A600>0.33</color>��/��\r\n���I:���ʳt�״��<color=#FF0000>0.5</color>", "�j��:��h�u\r\n�ĪG:�o�g�@�ӭ��®g����V����h�u�A����@��μ��쪫����z���A�z���ɵo�g8�o�l�u���¤��P��V�A�C�@�Ӥl�u�y��<color=#07A600>1</color>�I�ˮ`\r\n�N�o:5��", "���˦b��訤��O���ʩZ�J�ɨϥΡA�i�H�b�}�Ҥj�ۮɥάy�u���L�C");
                break;
            case 5:
                player(tankimages[4], "�a�p�Z�J", smoveimages[4], "�u�I:���t�W�[<color=#07A600>0.25</color>\r\n���I:<color=#07A600>�S�����I</color>", "�j��:�S���q���A�]�઱��a�p\r\n�ĪG:�w��2���(�w�ˮɽ�줣�|���ˡA���|�l�a)�A��m�@�Ӧa�p(�ͩR:3)�b�a���W�A�z���y��<color=#07A600>1</color>�I�ˮ`�A�v���줣�|����\r\n�N�o:5��A�i�s��<color=#07A600>5</color>��", "���˦b��訤��O���ʩZ�J�ɨϥΡA�a�p�i�H�b�L�}�ҥ[�t�ɤ��g�N������L�C");
                break;
        }
    }
    
    //�C���}�l�ɷǳ�
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
            mapname_T.text = "�g��";
            map_I.sprite = mapimages[0];
            map = true;
            PlayerPrefs.SetString("map", "map01");
        }
        if (map02_TG.isOn)
        {
            mapname_T.text = "�԰�";
            map_I.sprite = mapimages[1];
            map = true;
            PlayerPrefs.SetString("map", "map02");
        }
    }

    //���i
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

    //�U�C���s
    public void allclose()
    {
        store.SetActive(false);
        tank.SetActive(false);
        activity.SetActive(false);
        about.SetActive(false);
    }

    //���}
    public void quit()
    {
        Application.Quit();
    }
}
