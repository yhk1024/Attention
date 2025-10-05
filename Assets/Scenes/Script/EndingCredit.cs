using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCredit : MonoBehaviour
{
    public GameObject go;
    private string previousEndKey = "previousEnd"; // PlayerPrefs Ű �� - ���� ����
    string previousEnd;

    public float delayInSeconds = 15f; // ȭ�� ��ȯ ������ ����


    void Start()
    {
    }

    void Update()
    {
        previousEnd = PlayerPrefs.GetString(previousEndKey);   //previousBgKey Ű ���� ����� �� �ҷ����� - ��������
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(previousEnd == "end")
        {
            go.SetActive(true);

            Invoke("OnClickMain", delayInSeconds); // ���� �ð� �� OnClickMain() �Լ� ȣ��
        }
    }

    public void OnClickMain()
    {
        SceneManager.LoadScene("Main");
    }
}
