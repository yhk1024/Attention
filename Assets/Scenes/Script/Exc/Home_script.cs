using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_script : MonoBehaviour
{
    private string previousBgKey = "previousBg"; // PlayerPrefs 키 값 - 배경
    string previousBg;

    Color sadColor = new Color(0.6784314f, 0.7529412f, 0.9058824f); // 빨강, 녹색, 파랑, 알파 값으로 색상을 생성
    Color happyColor = new Color(0.9058824f, 0.6745098f, 0.6901961f); // 화면이 변할 색상

    public SpriteRenderer spriteRenderer; // 해당 오브젝트의 SpriteRenderer를 여기에 연결해야 합니다.
    public Renderer objectRenderer; // 오브젝트의 Renderer
    public float duration = 5.0f; // 어둡게 되는 데 걸리는 시간
    private Color initialColor; // 초기 색상
    private Color currentColor; // 현재 색상

    public GameObject BedSad;
    public GameObject BedHappy;
    public GameObject BedSadText;
    public GameObject BedHappyText;


    // Start is called before the first frame update
    void Start()
    {
        initialColor = objectRenderer.material.color; // 초기 색상 설정
        currentColor = initialColor;
    }

    // Update is called once per frame
    void Update()
    {
        previousBg = PlayerPrefs.GetString(previousBgKey);   //previousBgKey 키 값에 저장된 값 불러오기 - 감정상태

        if(previousBg == "happy")
        {
            StartCoroutine(ChangeColorOverTime());
            BedSad.SetActive(false);
            BedSadText.SetActive(false);

            BedHappy.SetActive(true);
            BedHappyText.SetActive(true);
        }
    }


    IEnumerator ChangeColorOverTime()
    {
        Color startColor = spriteRenderer.color; // 초기 색상

        float startTime = Time.time; // 시작 시간

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            currentColor = Color.Lerp(initialColor, happyColor, t);
            spriteRenderer.color = currentColor;

            yield return null;
        }

        spriteRenderer.color = happyColor; // 최종 색상 설정
    }

}
