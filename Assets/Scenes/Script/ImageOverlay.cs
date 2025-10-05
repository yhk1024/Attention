using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageOverlay : MonoBehaviour
{
    private bool playerDeceted; //감지 여부 확인
    public Transform ImgPos;   //감지 중심 위치
    public Vector2 size;    //감지 범위
    public LayerMask whatIsPlayer;  //감지할 대상

    public Image imageToFade;
    public Image imageToFade2;
    public float fadeDuration = 2.0f; // 페이드 시간 (초)
    private float fadeTimer = 0.0f;
    private bool fadeOff = false;
    private bool fadeOn = false;
    private bool fadeOff2 = false;

    string currentScene;
    private string previousSceneKey = "PreviousScene"; // PlayerPrefs 키 값 - 화면
    private string previousBgKey = "previousBg"; // PlayerPrefs 키 값 - 감정
    private string previousEndKey = "previousEnd"; // PlayerPrefs 키 값 - 엔딩 여부
    string previousBg; // PlayerPrefs 키 값 - 감정


    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        string previousScene = PlayerPrefs.GetString(previousSceneKey);
        previousBg = PlayerPrefs.GetString(previousBgKey);

        // 이미지를 처음에 완전히 투명하게 설정
        Color imageColor = imageToFade.color;
        imageColor.a = 0.0f;
        imageToFade.color = imageColor;


        if (currentScene == "Street" &&  previousScene == "Main")
        {
            Invoke("EndFading", 0.0f); // 2초 후에 페이드 시작
            ImageFadeOff();
            ImageFadeOn();
        }
        
        if (currentScene == "Home")
        {
            Color imageColor2 = imageToFade2.color;
            imageColor2.a = 0.0f;
            imageToFade2.color = imageColor2;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(currentScene == "Home")
        {
            ImageFadeOff();
            ImageFadeOff2();
            ImageFadeOn2();
        }
        else
        {
            ImageFadeOff();
            ImageFadeOn();
        }

        playerDeceted = Physics2D.OverlapBox(ImgPos.position, size, 0, whatIsPlayer);   //범위 안에 들어왔는지 감지
        //Debug.Log("playerDeceted : " + playerDeceted);

        //범위 안에 들어오면 실행
        if (playerDeceted == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // 일정 시간 후 페이드 시작
                Invoke("EndFading", 1.0f); // 2초 후에 페이드 시작
            }
        }
    }


    //이미지 점점 보여주기
    void ImageFadeOff()
    {
        if (fadeOff)
        {
            //Debug.Log("fadeTimer : " + fadeTimer);
            //Debug.Log("Time.deltaTime : " + Time.deltaTime);

            fadeTimer += Time.deltaTime;
            if (fadeTimer < fadeDuration)
            {
                // 일정 시간 동안 점진적으로 알파 값을 감소시킴
                Color imageColor = imageToFade.color;
                imageColor.a = 0.0f + (fadeTimer / fadeDuration);
                imageToFade.color = imageColor;
            }
            else
            {
                // 일정 시간이 지나면 이미지를 완전히 투명하게 만듦
                Color imageColor = imageToFade.color;
                imageColor.a = 1.0f;
                imageToFade.color = imageColor;
                fadeOff = false;

                fadeTimer = 0.0f;

                if(currentScene == "Home")
                {
                    Invoke("EndFading2", 3.0f); // 3초 후에 페이드 시작
                } else
                {
                    // 일정 시간 후 페이드 시작
                    Invoke("StartFading", 3.0f); // 3초 후에 페이드 시작
                }
            }
        }
    }

    //이미지 점점 사라지기
    void ImageFadeOn()
    {
        if (fadeOn)
        {
            fadeTimer += Time.deltaTime;
            if (fadeTimer < fadeDuration)
            {
                // 일정 시간 동안 점진적으로 알파 값을 감소시킴
                Color imageColor = imageToFade.color;
                imageColor.a = 1.0f - (fadeTimer / fadeDuration);
                imageToFade.color = imageColor;
            }
            else
            {
                // 일정 시간이 지나면 이미지를 완전히 투명하게 만듦
                Color imageColor = imageToFade.color;
                imageColor.a = 0.0f;
                imageToFade.color = imageColor;
                fadeOn = false;

                if(currentScene == "Street" && previousBg == "sad2")
                {
                    PlayerPrefs.SetString(previousEndKey, "end");   //행복한 상태로 변경
                }
            }
        }
    }

    //이미지1은 점점 흐려지면서 이미지2는 점점 또렷하게
    void ImageFadeOff2()
    {
        if (fadeOff2)
        {
            //Debug.Log("fadeTimer : " + fadeTimer);
            //Debug.Log("Time.deltaTime : " + Time.deltaTime);

            fadeTimer += Time.deltaTime;
            if (fadeTimer < fadeDuration)
            {
                // 일정 시간 동안 점진적으로 알파 값을 감소시킴
                Color imageColor = imageToFade.color;
                imageColor.a = 1.0f - (fadeTimer / fadeDuration);
                imageToFade.color = imageColor;

                // 일정 시간 동안 점진적으로 알파 값을 증가시킴
                Color imageColor2 = imageToFade.color;
                imageColor2.a = 0.0f + (fadeTimer / fadeDuration);
                imageToFade2.color = imageColor2;
            }
            else
            {
                // 일정 시간이 지나면 이미지를 완전히 투명하게 만듦
                Color imageColor = imageToFade.color;
                imageColor.a = 0.0f;
                imageToFade.color = imageColor;

                fadeTimer = 0.0f;

                // 일정 시간이 지나면 이미지를 완전히 투명하게 만듦
                Color imageColor2 = imageToFade.color;
                imageColor2.a = 1.0f;
                imageToFade2.color = imageColor2;

                fadeOff2 = false;
                Invoke("StartFading", 3.0f); // 3초 후에 페이드 시작
            }
        }
    }

    //이미지 점점 사라지기
    void ImageFadeOn2()
    {
        if (fadeOn)
        {
            //Debug.Log("fadeTimer : " + fadeTimer);
            //Debug.Log("Time.deltaTime : " + Time.deltaTime);

            fadeTimer += Time.deltaTime;
            if (fadeTimer < fadeDuration)
            {
                // 일정 시간 동안 점진적으로 알파 값을 감소시킴
                Color imageColor2 = imageToFade2.color;
                imageColor2.a = 1.0f - (fadeTimer / fadeDuration);
                imageToFade2.color = imageColor2;
            }
            else
            {
                // 일정 시간이 지나면 이미지를 완전히 투명하게 만듦
                Color imageColor2 = imageToFade2.color;
                imageColor2.a = 0.0f;
                imageToFade2.color = imageColor2;
                fadeOn = false;

                fadeTimer = 0.0f;

                PlayerPrefs.SetString(previousBgKey, "happy");   //행복한 상태로 변경
            }
        }
    }

    void EndFading()
    {
        fadeOff = true;
    }

    void StartFading()
    {
        fadeOn = true;
    }

    void EndFading2()
    {
        fadeOff2 = true;
    }
}
