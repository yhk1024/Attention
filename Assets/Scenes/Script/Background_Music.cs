using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Background_Music : MonoBehaviour
{
    private static Background_Music instance;
    public AudioSource audioSource1; // ������� AudioSource
    public AudioSource audioSource2; // ������� AudioSource
    public AudioSource audioSource3; // ������� AudioSource

    private string previousBgKey = "previousBg"; // PlayerPrefs Ű �� - ����
    string previousBg;


    // Start is called before the first frame update
    void Start()
    {
        // ������� ��� �� ���� �ݺ� ����
        audioSource1.loop = true;
        audioSource2.loop = true;
        audioSource3.loop = true;

        audioSource1.Play();
    }

    // Update is called once per frame
    void Update()
    {
        previousBg = PlayerPrefs.GetString(previousBgKey);   //previousBgKey Ű ���� ����� �� �ҷ����� - ��������

        //���� ������ 'happy'�� ���, �ʹ� �뷡���� �߹� �뷡�� ����
        //���� ������ 'sad2'�� ���, �߹� �뷡���� �Ĺ� �뷡�� ����
        if (previousBg == "happy")
        {
            if (audioSource1.isPlaying)
            {
                audioSource1.Pause();
                audioSource2.Play();
            }
        }
        else if (previousBg == "sad2")
        {
            if (audioSource2.isPlaying)
            {
                audioSource2.Pause();
                audioSource3.Play();
            }
        }
    }


    void Awake()
    {
        // ����� �Ŵ��� �̱��� �������� �����Ͽ� �� ���� �����ǵ��� ��
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject); // �̹� �����ϴ� ��� �ߺ��� ����� �Ŵ��� �ı�
        }
    }
}
