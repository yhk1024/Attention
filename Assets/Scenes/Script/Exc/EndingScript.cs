using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    private string previousEndKey = "previousEnd"; // PlayerPrefs 키 값 - 엔딩 여부
    string previousEnd;
    public float Speed = 4.0f;  //캐릭터 속도

    Vector3 position;

    public float minX = -8f; // X 좌표 최소값
    public float maxX = 8f; // X 좌표 최대값


    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        previousEnd = PlayerPrefs.GetString(previousEndKey);   //엔딩 여부 확인

        if (previousEnd == "end")
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(horizontalInput, 0.0f, 0.0f) * Speed * Time.deltaTime;
            Vector3 newPosition = transform.position + movement;

            // 새로운 위치가 허용된 범위 내에 있는지 확인
            if (newPosition.x >= minX && newPosition.x <= maxX)
            {
                // 허용된 범위 내에 있다면 이동 실행
                transform.Translate(movement);
            }
        }
    }
}
