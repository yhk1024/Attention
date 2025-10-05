using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open : MonoBehaviour
{
    [SerializeField] private string sceneName;  //이동할 화면 이름

    private bool playerDeceted; //감지 여부 확인
    public Transform doorPos;   //감지 중심 위치
    public Vector2 size;    //감지 범위
    public LayerMask whatIsPlayer;  //감지할 대상

    Scene_Change sceneChange;   //다른 스크립트

    private string previousSceneKey = "PreviousScene"; // PlayerPrefs 키 값 - 화면
    private string previousBgKey = "previousBg"; // PlayerPrefs 키 값 - 감정
    string previousBg;


    // Start is called before the first frame update
    void Start()
    {
        sceneChange = FindObjectOfType<Scene_Change>(); //다른 스크립트 불러오기

        previousBg = PlayerPrefs.GetString(previousBgKey);   //previousBgKey 키 값에 저장된 값 불러오기 - 감정상태
    }

    // Update is called once per frame
    void Update()
    {
        playerDeceted = Physics2D.OverlapBox(doorPos.position, size, 0, whatIsPlayer);  //범위 안에 플레이어가 있을 경우

        if (playerDeceted == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                sceneChange.SceneChange(sceneName);
                // 이전 씬 정보 가져오기
                string previousScene = PlayerPrefs.GetString(previousSceneKey);
                Debug.Log("open 이전 씬: " + previousScene);

                if (sceneChange.currentScene == "Mart" && previousBg == "happy")
                {
                    PlayerPrefs.SetString(previousBgKey, "sad2");
                }
            }
        }
    }


    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }*/
}
