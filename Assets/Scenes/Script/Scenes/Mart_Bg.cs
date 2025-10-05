using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mart_Setting : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // 해당 오브젝트의 SpriteRenderer를 여기에 연결해야 합니다.

    private string previousSceneKey = "PreviousScene"; // PlayerPrefs 키 값 - 화면
    private string previousBgKey = "previousBg"; // PlayerPrefs 키 값 - 감정
    string previousBg;
    string currentScene;
    public Sprite sadImg;
    public Sprite happyImg;

    public GameObject Friend;    //친구
    public GameObject FriendCheck;    //친구


    // Start is called before the first frame update
    void Start()
    {
        previousBg = PlayerPrefs.GetString(previousBgKey);   //previousBgKey 키 값에 저장된 값 불러오기 - 감정상태
        currentScene = PlayerPrefs.GetString(previousSceneKey); ;

        BackgroundColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BackgroundColor()
    {
        //현재 감정상태가 'sad'일 경우
        if (previousBg == "sad")
        {
            spriteRenderer.sprite = sadImg;  // 다른 Sprite로 변경
            spriteRenderer.color = Color.white; // 하얀색으로 변경
        }
        else if (previousBg == "happy")  //현재 감정상태가 'happy'일 경우
        {
            spriteRenderer.sprite = happyImg;  // 다른 Sprite로 변경
            spriteRenderer.color = Color.white; // 하얀색으로 변경
        }
    }
}
