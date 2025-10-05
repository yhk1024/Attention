using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mart_script : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // �ش� ������Ʈ�� SpriteRenderer�� ���⿡ �����ؾ� �մϴ�.
    public SpriteRenderer martNPC;  //��Ʈ����

    private string previousSceneKey = "PreviousScene"; // PlayerPrefs Ű �� - ȭ��
    private string previousBgKey = "previousBg"; // PlayerPrefs Ű �� - ����
    string previousBg;
    string currentScene;

    public Sprite sadImg;
    public Sprite happyImg;
    public Sprite sadNPC;
    public Sprite happyNPC;

    public GameObject MartSad;    //���� ��
    public GameObject MartSadText;    //���� ��

    public GameObject MartHappy;    //�ູ�� ��
    public GameObject MartHappyText;    //�ູ�� ��

    // Start is called before the first frame update
    void Start()
    {
        previousBg = PlayerPrefs.GetString(previousBgKey);   //previousBgKey Ű ���� ����� �� �ҷ����� - ��������
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
        //���� �������°� 'happy'�� ���
        if (previousBg == "happy")
        {
            spriteRenderer.sprite = happyImg;  // �ٸ� Sprite�� ���� 
            martNPC.sprite = happyNPC;  // �ٸ� Sprite�� ���� 
            spriteRenderer.color = Color.white; // �Ͼ������ ����
        }
        else  //���� �������°� 'sad'�� ���
        {
            spriteRenderer.sprite = sadImg;  // �ٸ� Sprite�� ����
            martNPC.sprite = sadNPC;  // �ٸ� Sprite�� ����
            spriteRenderer.color = Color.white; // �Ͼ������ ����
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
