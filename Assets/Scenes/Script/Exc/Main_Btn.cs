using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Btn : MonoBehaviour
{
    public GameObject PopUp;

    private string previousBgKey = "previousBg"; // PlayerPrefs 키 값 - 감정
    private string previousEndKey = "previousEnd"; // PlayerPrefs 키 값 - 엔딩 여부
    Scene_Change sceneChange;   //다른 스크립트


    // Start is called before the first frame update
    void Start()
    {
        string previousBg = PlayerPrefs.GetString(previousBgKey);
        if (previousBg == "sad2")
        {
            PopUp.SetActive(false);
        }
        PlayerPrefs.DeleteAll();    //모든 데이터 삭제

        sceneChange = FindObjectOfType<Scene_Change>(); //다른 스크립트 불러오기
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStart()
    {
        PlayerPrefs.SetString(previousBgKey, "sad");   //우울한 상태
        PlayerPrefs.SetString(previousEndKey, "start");   //우울한 상태

        sceneChange.SceneChange("Street");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
