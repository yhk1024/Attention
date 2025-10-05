using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    private string previousEndKey = "previousEnd"; // PlayerPrefs Ű �� - ���� ����
    string previousEnd;
    public float Speed = 4.0f;  //ĳ���� �ӵ�

    Vector3 position;

    public float minX = -8f; // X ��ǥ �ּҰ�
    public float maxX = 8f; // X ��ǥ �ִ밪


    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        previousEnd = PlayerPrefs.GetString(previousEndKey);   //���� ���� Ȯ��

        if (previousEnd == "end")
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(horizontalInput, 0.0f, 0.0f) * Speed * Time.deltaTime;
            Vector3 newPosition = transform.position + movement;

            // ���ο� ��ġ�� ���� ���� ���� �ִ��� Ȯ��
            if (newPosition.x >= minX && newPosition.x <= maxX)
            {
                // ���� ���� ���� �ִٸ� �̵� ����
                transform.Translate(movement);
            }
        }
    }
}
