using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mart_script : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // 해당 오브젝트의 SpriteRenderer를 여기에 연결해야 합니다.
    public SpriteRenderer martNPC;  //마트직원

    private string previousSceneKey = "PreviousScene"; // PlayerPrefs 키 값 - 화면
    private string previousBgKey = "previousBg"; // PlayerPrefs 키 값 - 감정
    string previousBg;
    string currentScene;

    public Sprite sadImg;
    public Sprite happyImg;
    public Sprite sadNPC;
    public Sprite happyNPC;

    public GameObject MartSad;    //슬플 때
    public GameObject MartSadText;    //슬플 때

    public GameObject MartHappy;    //행복할 때
    public GameObject MartHappyText;    //행복할 때

    // Start is called before the first frame update
    void Start()
    {
        previousBg = PlayerPrefs.GetString(previousBgKey);   //previousBgKey 키 값에 저장된 값 불러오기 - 감정상태
        currentScene = PlayerPrefs.GetString(previousSceneKey);

        BackgroundColor();
        FeelingCheck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BackgroundColor()
    {
        //현재 감정상태가 'happy'일 경우
        if (previousBg == "happy")
        {
            spriteRenderer.sprite = happyImg;  // 다른 Sprite로 변경 
            martNPC.sprite = happyNPC;  // 다른 Sprite로 변경 
            spriteRenderer.color = Color.white; // 하얀색으로 변경
        }
        else  //현재 감정상태가 'sad'일 경우
        {
            spriteRenderer.sprite = sadImg;  // 다른 Sprite로 변경
            martNPC.sprite = sadNPC;  // 다른 Sprite로 변경
            spriteRenderer.color = Color.white; // 하얀색으로 변경
        }
    }

    void FeelingCheck()
    {
        if (previousBg == "happy")
        {
            MartHappy.SetActive(true);
            MartHappyText.SetActive(true);

            MartSad.SetActive(false);
            MartSadText.SetActive(false);
        }
        else
        {
            MartHappy.SetActive(false);
            MartHappyText.SetActive(false);

            MartSad.SetActive(true);
            MartSadText.SetActive(true);
        }
    }
}
