using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Street_Setting : MonoBehaviour
{
    private string previousSceneKey = "PreviousScene"; // PlayerPrefs Ű �� - ȭ��
    private string previousBgKey = "previousBg"; // PlayerPrefs Ű �� - ����
    string previousScene;  //PlayerPrefs ���� ������ ����
    string previousBg;  //PlayerPrefs ���� ������ ����

    public GameObject PlayerPos;    //�÷��̾� ��ġ

    public GameObject DoorHome;    //��
    public GameObject DoorRes_1;    //�Ĵ�1
    public GameObject DoorRes_2;    //�Ĵ�2
    public GameObject DoorMart;    //����

    public GameObject Friend;    //ģ��
    public GameObject FriendCheck;    //ģ��
    public GameObject Real;    //����
    public GameObject RealCheck;    //����

    public GameObject HomeText;
    public GameObject Res1Text;
    public GameObject Res2Text;
    public GameObject MartText;
    public GameObject FriendText;
    public GameObject RealText;


    // Start is called before the first frame update
    void Start()
    {
        previousScene = PlayerPrefs.GetString(previousSceneKey);    //���� ȭ��
        previousBg = PlayerPrefs.GetString(previousBgKey);    //���� ����

        if (previousBg == "happy" && previousScene == "Mart")
        {
            PlayerPrefs.SetString(previousBgKey, "sad2");
        }

        DoorAction();
        FeelingCheck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //���� ȭ�鿡 ���� Street���� Ȱ��ȭ �ϴ� �� ����
    void DoorAction()
    {
        if (previousScene == "Main")
        {
            PlayerPos.SetActive(true);

            DoorHome.SetActive(false);
            DoorRes_1.SetActive(true);
            DoorRes_2.SetActive(false);
            DoorMart.SetActive(false);

            HomeText.SetActive(false);
            Res1Text.SetActive(true);
            Res2Text.SetActive(false);
            MartText.SetActive(false);
        }
        else if (previousScene == "Res_1")
        {
            PlayerPos.SetActive(false);

            DoorHome.SetActive(false);
            DoorRes_1.SetActive(true);
            DoorRes_2.SetActive(false);
            DoorMart.SetActive(true);

            HomeText.SetActive(false);
            Res1Text.SetActive(true);
            Res2Text.SetActive(false);
            MartText.SetActive(true);
        }
        else if (previousScene == "Mart")
        {
            PlayerPos.SetActive(false);

            DoorHome.SetActive(true);
            DoorRes_1.SetActive(false);
            DoorRes_2.SetActive(false);
            DoorMart.SetActive(true);

            HomeText.SetActive(true);
            Res1Text.SetActive(false);
            Res2Text.SetActive(false);
            MartText.SetActive(true);

        }
        else if (previousScene == "Home")
        {
            PlayerPos.SetActive(false);

            DoorHome.SetActive(true);
            DoorRes_1.SetActive(false);
            DoorRes_2.SetActive(true);
            DoorMart.SetActive(false);

            HomeText.SetActive(false);
            Res1Text.SetActive(false);
            Res2Text.SetActive(true);
            MartText.SetActive(false);
        }
        else if (previousScene == "Res_2")
        {
            PlayerPos.SetActive(false);

            DoorHome.SetActive(false);
            DoorRes_1.SetActive(false);
            DoorRes_2.SetActive(true);
            DoorMart.SetActive(true);

            HomeText.SetActive(false);
            Res1Text.SetActive(false);
            Res2Text.SetActive(true);
            MartText.SetActive(true);
        }
    }

    void FeelingCheck()
    {
        if(previousBg == "happy")
        {
            Friend.SetActive(true);
            FriendCheck.SetActive(true);
            FriendText.SetActive(true);

            Real.SetActive(false);
            RealCheck.SetActive(false);
            RealText.SetActive(false);

            if(previousScene == "Res_2")
            {
                Friend.SetActive(false);
                FriendCheck.SetActive(false);
                FriendText.SetActive(false);
            }

        } else if (previousBg == "sad2")
        {
            Friend.SetActive(false);
            FriendCheck.SetActive(false);
            FriendText.SetActive(false);

            Real.SetActive(true);
            RealCheck.SetActive(true);
            RealText.SetActive(true);
        } else
        {
            Friend.SetActive(false);
            FriendCheck.SetActive(false);
            FriendText.SetActive(false);

            Real.SetActive(false);
            RealCheck.SetActive(false);
            RealText.SetActive(false);
        }
    }
}
