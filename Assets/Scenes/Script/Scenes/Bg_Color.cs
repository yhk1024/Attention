using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg_Color : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // 해당 오브젝트의 SpriteRenderer를 여기에 연결해야 합니다.

    private string previousBgKey = "previousBg"; // PlayerPrefs 키 값 - 감정
    string previousBg;

    Color sadColor = new Color(0.6784314f, 0.7529412f, 0.9058824f); // 빨강, 녹색, 파랑, 알파 값으로 색상을 생성
    Color happyColor = new Color(0.9058824f, 0.6745098f, 0.6901961f); // 빨강, 녹색, 파랑, 알파 값으로 색상을 생성


    // Start is called before the first frame update
    void Start()
    {
        previousBg = PlayerPrefs.GetString(previousBgKey);   //previousBgKey 키 값에 저장된 값 불러오기 - 감정상태

        BackgroundColor();

        Debug.Log("previousBg : " + previousBg);
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
            spriteRenderer.color = happyColor; // 빨간색으로 변경
        }
        else //현재 감정상태가 'sad'일 경우
        {
            spriteRenderer.color = sadColor; // 파란색으로 변경
        }
    }
}
