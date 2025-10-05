using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Btn : MonoBehaviour
{
    public GameObject PopUp;

    private string previousBgKey = "previousBg"; // PlayerPrefs Ű �� - ����
    private string previousEndKey = "previousEnd"; // PlayerPrefs Ű �� - ���� ����
    Scene_Change sceneChange;   //�ٸ� ��ũ��Ʈ


    // Start is called before the first frame update
    void Start()
    {
        string previousBg = PlayerPrefs.GetString(previousBgKey);
        if (previousBg == "sad2")
        {
            PopUp.SetActive(false);
        }
        PlayerPrefs.DeleteAll();    //��� ������ ����

        sceneChange = FindObjectOfType<Scene_Change>(); //�ٸ� ��ũ��Ʈ �ҷ�����
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStart()
    {
        PlayerPrefs.SetString(previousBgKey, "sad");   //����� ����
        PlayerPrefs.SetString(previousEndKey, "start");   //����� ����

        sceneChange.SceneChange("Street");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
