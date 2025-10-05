using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCredit : MonoBehaviour
{
    public GameObject go;
    private string previousEndKey = "previousEnd"; // PlayerPrefs 키 값 - 엔딩 여부
    string previousEnd;

    public float delayInSeconds = 15f; // 화면 전환 딜레이 설정


    void Start()
    {
    }

    void Update()
    {
        previousEnd = PlayerPrefs.GetString(previousEndKey);   //previousBgKey 키 값에 저장된 값 불러오기 - 감정상태
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(previousEnd == "end")
        {
            go.SetActive(true);

            Invoke("OnClickMain", delayInSeconds); // 일정 시간 후 OnClickMain() 함수 호출
        }
    }

    public void OnClickMain()
    {
        SceneManager.LoadScene("Main");
    }
}
