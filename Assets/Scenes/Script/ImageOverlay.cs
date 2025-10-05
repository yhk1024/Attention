using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageOverlay : MonoBehaviour
{
    private bool playerDeceted; //���� ���� Ȯ��
    public Transform ImgPos;   //���� �߽� ��ġ
    public Vector2 size;    //���� ����
    public LayerMask whatIsPlayer;  //������ ���

    public Image imageToFade;
    public Image imageToFade2;
    public float fadeDuration = 2.0f; // ���̵� �ð� (��)
    private float fadeTimer = 0.0f;
    private bool fadeOff = false;
    private bool fadeOn = false;
    private bool fadeOff2 = false;

    string currentScene;
    private string previousSceneKey = "PreviousScene"; // PlayerPrefs Ű �� - ȭ��
    private string previousBgKey = "previousBg"; // PlayerPrefs Ű �� - ����
    private string previousEndKey = "previousEnd"; // PlayerPrefs Ű �� - ���� ����
    string previousBg; // PlayerPrefs Ű �� - ����


    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        string previousScene = PlayerPrefs.GetString(previousSceneKey);
        previousBg = PlayerPrefs.GetString(previousBgKey);

        // �̹����� ó���� ������ �����ϰ� ����
        Color imageColor = imageToFade.color;
        imageColor.a = 0.0f;
        imageToFade.color = imageColor;


        if (currentScene == "Street" &&  previousScene == "Main")
        {
            Invoke("EndFading", 0.0f); // 2�� �Ŀ� ���̵� ����
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

        playerDeceted = Physics2D.OverlapBox(ImgPos.position, size, 0, whatIsPlayer);   //���� �ȿ� ���Դ��� ����
        //Debug.Log("playerDeceted : " + playerDeceted);

        //���� �ȿ� ������ ����
        if (playerDeceted == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // ���� �ð� �� ���̵� ����
                Invoke("EndFading", 1.0f); // 2�� �Ŀ� ���̵� ����
            }
        }
    }


    //�̹��� ���� �����ֱ�
    void ImageFadeOff()
    {
        if (fadeOff)
        {
            //Debug.Log("fadeTimer : " + fadeTimer);
            //Debug.Log("Time.deltaTime : " + Time.deltaTime);

            fadeTimer += Time.deltaTime;
            if (fadeTimer < fadeDuration)
            {
                // ���� �ð� ���� ���������� ���� ���� ���ҽ�Ŵ
                Color imageColor = imageToFade.color;
                imageColor.a = 0.0f + (fadeTimer / fadeDuration);
                imageToFade.color = imageColor;
            }
            else
            {
                // ���� �ð��� ������ �̹����� ������ �����ϰ� ����
                Color imageColor = imageToFade.color;
                imageColor.a = 1.0f;
                imageToFade.color = imageColor;
                fadeOff = false;

                fadeTimer = 0.0f;

                if(currentScene == "Home")
                {
                    Invoke("EndFading2", 3.0f); // 3�� �Ŀ� ���̵� ����
                } else
                {
                    // ���� �ð� �� ���̵� ����
                    Invoke("StartFading", 3.0f); // 3�� �Ŀ� ���̵� ����
                }
            }
        }
    }

    //�̹��� ���� �������
    void ImageFadeOn()
    {
        if (fadeOn)
        {
            fadeTimer += Time.deltaTime;
            if (fadeTimer < fadeDuration)
            {
                // ���� �ð� ���� ���������� ���� ���� ���ҽ�Ŵ
                Color imageColor = imageToFade.color;
                imageColor.a = 1.0f - (fadeTimer / fadeDuration);
                imageToFade.color = imageColor;
            }
            else
            {
                // ���� �ð��� ������ �̹����� ������ �����ϰ� ����
                Color imageColor = imageToFade.color;
                imageColor.a = 0.0f;
                imageToFade.color = imageColor;
                fadeOn = false;

                if(currentScene == "Street" && previousBg == "sad2")
                {
                    PlayerPrefs.SetString(previousEndKey, "end");   //�ູ�� ���·� ����
                }
            }
        }
    }

    //�̹���1�� ���� ������鼭 �̹���2�� ���� �Ƿ��ϰ�
    void ImageFadeOff2()
    {
        if (fadeOff2)
        {
            //Debug.Log("fadeTimer : " + fadeTimer);
            //Debug.Log("Time.deltaTime : " + Time.deltaTime);

            fadeTimer += Time.deltaTime;
            if (fadeTimer < fadeDuration)
            {
                // ���� �ð� ���� ���������� ���� ���� ���ҽ�Ŵ
                Color imageColor = imageToFade.color;
                imageColor.a = 1.0f - (fadeTimer / fadeDuration);
                imageToFade.color = imageColor;

                // ���� �ð� ���� ���������� ���� ���� ������Ŵ
                Color imageColor2 = imageToFade.color;
                imageColor2.a = 0.0f + (fadeTimer / fadeDuration);
                imageToFade2.color = imageColor2;
            }
            else
            {
                // ���� �ð��� ������ �̹����� ������ �����ϰ� ����
                Color imageColor = imageToFade.color;
                imageColor.a = 0.0f;
                imageToFade.color = imageColor;

                fadeTimer = 0.0f;

                // ���� �ð��� ������ �̹����� ������ �����ϰ� ����
                Color imageColor2 = imageToFade.color;
                imageColor2.a = 1.0f;
                imageToFade2.color = imageColor2;

                fadeOff2 = false;
                Invoke("StartFading", 3.0f); // 3�� �Ŀ� ���̵� ����
            }
        }
    }

    //�̹��� ���� �������
    void ImageFadeOn2()
    {
        if (fadeOn)
        {
            //Debug.Log("fadeTimer : " + fadeTimer);
            //Debug.Log("Time.deltaTime : " + Time.deltaTime);

            fadeTimer += Time.deltaTime;
            if (fadeTimer < fadeDuration)
            {
                // ���� �ð� ���� ���������� ���� ���� ���ҽ�Ŵ
                Color imageColor2 = imageToFade2.color;
                imageColor2.a = 1.0f - (fadeTimer / fadeDuration);
                imageToFade2.color = imageColor2;
            }
            else
            {
                // ���� �ð��� ������ �̹����� ������ �����ϰ� ����
                Color imageColor2 = imageToFade2.color;
                imageColor2.a = 0.0f;
                imageToFade2.color = imageColor2;
                fadeOn = false;

                fadeTimer = 0.0f;

                PlayerPrefs.SetString(previousBgKey, "happy");   //�ູ�� ���·� ����
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
