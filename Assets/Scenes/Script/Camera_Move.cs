using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
    public Transform player;
    public float smoothing = 0.2f;
    public Vector2 minCameraBoundary; //카메라가 갈 수 있는 최솟값
    public Vector2 maxCameraBoundary; //카메라가 갈 수 있는 최댓값


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
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, this.transform.position.z);   //대상의 위치

        targetPos.x = Mathf.Clamp(targetPos.x, minCameraBoundary.x, maxCameraBoundary.x);   //대상 위치의 x값
        targetPos.y = Mathf.Clamp(targetPos.y, minCameraBoundary.y, maxCameraBoundary.y);   //대상 위치의 y값

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);    //카메라가 따라가는 속도
    }
}
