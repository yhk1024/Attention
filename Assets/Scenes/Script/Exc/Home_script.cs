using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_script : MonoBehaviour
{
    private string previousBgKey = "previousBg"; // PlayerPrefs Ű �� - ���
    string previousBg;

    Color sadColor = new Color(0.6784314f, 0.7529412f, 0.9058824f); // ����, ���, �Ķ�, ���� ������ ������ ����
    Color happyColor = new Color(0.9058824f, 0.6745098f, 0.6901961f); // ȭ���� ���� ����

    public SpriteRenderer spriteRenderer; // �ش� ������Ʈ�� SpriteRenderer�� ���⿡ �����ؾ� �մϴ�.
    public Renderer objectRenderer; // ������Ʈ�� Renderer
    public float duration = 5.0f; // ��Ӱ� �Ǵ� �� �ɸ��� �ð�
    private Color initialColor; // �ʱ� ����
    private Color currentColor; // ���� ����

    public GameObject BedSad;
    public GameObject BedHappy;
    public GameObject BedSadText;
    public GameObject BedHappyText;


    // Start is called before the first frame update
    void Start()
    {
        initialColor = objectRenderer.material.color; // �ʱ� ���� ����
        currentColor = initialColor;
    }

    // Update is called once per frame
    void Update()
    {
        previousBg = PlayerPrefs.GetString(previousBgKey);   //previousBgKey Ű ���� ����� �� �ҷ����� - ��������

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
        Color startColor = spriteRenderer.color; // �ʱ� ����

        float startTime = Time.time; // ���� �ð�

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            currentColor = Color.Lerp(initialColor, happyColor, t);
            spriteRenderer.color = currentColor;

            yield return null;
        }

        spriteRenderer.color = happyColor; // ���� ���� ����
    }

}
