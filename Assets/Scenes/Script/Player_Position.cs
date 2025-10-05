using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Position : MonoBehaviour
{
    Vector3 position;
    public float Speed = 4.0f;  //캐릭터 속도
    public float Speed2 = 3.0f;  //캐릭터 속도
    SpriteRenderer rend;

    public float minX = -8f; // X 좌표 최소값
    public float maxX = 8f; // X 좌표 최대값

    string previousScene = "";  //PlayerPrefs 값을 저장할 변수
    private string previousSceneKey = "PreviousScene"; // PlayerPrefs 키 값 - 화면
    private string previousEndKey = "previousEnd"; // PlayerPrefs 키 값 - 엔딩 여부


    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        rend = GetComponent<SpriteRenderer>();

        //오브젝트가 가진 중력 비활성화
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0f; // 중력 비활성화

        previousScene = PlayerPrefs.GetString(previousSceneKey);    //이전 화면
        PlayerSetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        string previousEnd = PlayerPrefs.GetString(previousEndKey);   //엔딩 여부 확인

        if (previousEnd == "end")
        {
            transform.Translate(Vector3.left * Speed2 * Time.deltaTime);
        } else
        {
            PlayerMove();
        }
    }


    //화살표 방향으로 캐릭터 움직임
    public void PlayerMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, 0.0f) * Speed * Time.deltaTime;

        Vector3 newPosition = transform.position + movement;

        // 새로운 위치가 허용된 범위 내에 있는지 확인
        if (newPosition.x >= minX && newPosition.x <= maxX)
        {
            // 허용된 범위 내에 있다면 이동 실행
            transform.Translate(movement);

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rend.flipX = true;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rend.flipX = false;
            }
        }
        else
        {
            // 허용된 범위를 벗어나면 이동하지 않음
            Debug.Log("이동이 제한되었습니다!");
        }
    }

    //캐릭터의 이전 위치에 따라 x값 변경
    void PlayerSetPosition()
    {
        if (previousScene == "Home")
        {
            position.x = (float)-7;
        }
        else if (previousScene == "Res_1")
        {
            position.x = (float)-4.7;
        }
        else if (previousScene == "Res_2")
        {
            position.x = (float)2.1;
        }
        else if (previousScene == "Mart")
        {
            position.x = (float)5.5;
        }

        transform.position = position;
    }

}
