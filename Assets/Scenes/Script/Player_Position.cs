using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Position : MonoBehaviour
{
    Vector3 position;
    public float Speed = 4.0f;  //ĳ���� �ӵ�
    public float Speed2 = 3.0f;  //ĳ���� �ӵ�
    SpriteRenderer rend;

    public float minX = -8f; // X ��ǥ �ּҰ�
    public float maxX = 8f; // X ��ǥ �ִ밪

    string previousScene = "";  //PlayerPrefs ���� ������ ����
    private string previousSceneKey = "PreviousScene"; // PlayerPrefs Ű �� - ȭ��
    private string previousEndKey = "previousEnd"; // PlayerPrefs Ű �� - ���� ����


    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        rend = GetComponent<SpriteRenderer>();

        //������Ʈ�� ���� �߷� ��Ȱ��ȭ
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0f; // �߷� ��Ȱ��ȭ

        previousScene = PlayerPrefs.GetString(previousSceneKey);    //���� ȭ��
        PlayerSetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        string previousEnd = PlayerPrefs.GetString(previousEndKey);   //���� ���� Ȯ��

        if (previousEnd == "end")
        {
            transform.Translate(Vector3.left * Speed2 * Time.deltaTime);
        } else
        {
            PlayerMove();
        }
    }


    //ȭ��ǥ �������� ĳ���� ������
    public void PlayerMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, 0.0f) * Speed * Time.deltaTime;

        Vector3 newPosition = transform.position + movement;

        // ���ο� ��ġ�� ���� ���� ���� �ִ��� Ȯ��
        if (newPosition.x >= minX && newPosition.x <= maxX)
        {
            // ���� ���� ���� �ִٸ� �̵� ����
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
            // ���� ������ ����� �̵����� ����
            Debug.Log("�̵��� ���ѵǾ����ϴ�!");
        }
    }

    //ĳ������ ���� ��ġ�� ���� x�� ����
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
