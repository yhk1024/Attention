using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mart_Setting : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // �ش� ������Ʈ�� SpriteRenderer�� ���⿡ �����ؾ� �մϴ�.

    private string previousSceneKey = "PreviousScene"; // PlayerPrefs Ű �� - ȭ��
    private string previousBgKey = "previousBg"; // PlayerPrefs Ű �� - ����
    string previousBg;
    string currentScene;
    public Sprite sadImg;
    public Sprite happyImg;

    public GameObject Friend;    //ģ��
    public GameObject FriendCheck;    //ģ��


    // Start is called before the first frame update
    void Start()
    {
        previousBg = PlayerPrefs.GetString(previousBgKey);   //previousBgKey Ű ���� ����� �� �ҷ����� - ��������
        currentScene = PlayerPrefs.GetString(previousSceneKey); ;

        BackgroundColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BackgroundColor()
    {
        //���� �������°� 'sad'�� ���
        if (previousBg == "sad")
        {
            spriteRenderer.sprite = sadImg;  // �ٸ� Sprite�� ����
            spriteRenderer.color = Color.white; // �Ͼ������ ����
        }
        else if (previousBg == "happy")  //���� �������°� 'happy'�� ���
        {
            spriteRenderer.sprite = happyImg;  // �ٸ� Sprite�� ����
            spriteRenderer.color = Color.white; // �Ͼ������ ����
        }
    }
}
