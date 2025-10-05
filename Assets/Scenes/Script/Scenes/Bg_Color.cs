using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg_Color : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // �ش� ������Ʈ�� SpriteRenderer�� ���⿡ �����ؾ� �մϴ�.

    private string previousBgKey = "previousBg"; // PlayerPrefs Ű �� - ����
    string previousBg;

    Color sadColor = new Color(0.6784314f, 0.7529412f, 0.9058824f); // ����, ���, �Ķ�, ���� ������ ������ ����
    Color happyColor = new Color(0.9058824f, 0.6745098f, 0.6901961f); // ����, ���, �Ķ�, ���� ������ ������ ����


    // Start is called before the first frame update
    void Start()
    {
        previousBg = PlayerPrefs.GetString(previousBgKey);   //previousBgKey Ű ���� ����� �� �ҷ����� - ��������

        BackgroundColor();

        Debug.Log("previousBg : " + previousBg);
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
            spriteRenderer.color = happyColor; // ���������� ����
        }
        else //���� �������°� 'sad'�� ���
        {
            spriteRenderer.color = sadColor; // �Ķ������� ����
        }
    }
}
