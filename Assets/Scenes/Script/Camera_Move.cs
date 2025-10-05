using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
    public Transform player;
    public float smoothing = 0.2f;
    public Vector2 minCameraBoundary; //ī�޶� �� �� �ִ� �ּڰ�
    public Vector2 maxCameraBoundary; //ī�޶� �� �� �ִ� �ִ�


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, this.transform.position.z);   //����� ��ġ

        targetPos.x = Mathf.Clamp(targetPos.x, minCameraBoundary.x, maxCameraBoundary.x);   //��� ��ġ�� x��
        targetPos.y = Mathf.Clamp(targetPos.y, minCameraBoundary.y, maxCameraBoundary.y);   //��� ��ġ�� y��

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);    //ī�޶� ���󰡴� �ӵ�
    }
}
