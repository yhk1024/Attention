using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Background_Music : MonoBehaviour
{
    private static Background_Music instance;
    public AudioSource audioSource1; // 배경음악 AudioSource
    public AudioSource audioSource2; // 배경음악 AudioSource
    public AudioSource audioSource3; // 배경음악 AudioSource

    private string previousBgKey = "previousBg"; // PlayerPrefs 키 값 - 감정
    string previousBg;


    // Start is called before the first frame update
    void Start()
    {
        // 배경음악 재생 및 무한 반복 설정
        audioSource1.loop = true;
        audioSource2.loop = true;
        audioSource3.loop = true;

        audioSource1.Play();
    }

    // Update is called once per frame
    void Update()
    {
        previousBg = PlayerPrefs.GetString(previousBgKey);   //previousBgKey 키 값에 저장된 값 불러오기 - 감정상태

        //현재 감정이 'happy'일 경우, 초반 노래에서 중반 노래로 변경
        //현재 감정이 'sad2'일 경우, 중반 노래에서 후반 노래로 변경
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
        // 오디오 매니저 싱글톤 패턴으로 설정하여 한 번만 생성되도록 함
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 이미 존재하는 경우 중복된 오디오 매니저 파괴
        }
    }
}
