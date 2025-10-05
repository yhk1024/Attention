using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_Dialogue : MonoBehaviour
{
    public object[] dialogueArray; //가져올 배열
    public TMP_Text dialogueText; //대사 보여주는 곳
    public int listIndex;   //가져올 대사

    public GameObject NextF;    //다음 텍스트

    private bool playerDeceted; //감지 여부 확인
    public Transform NPCPos;   //감지 중심 위치
    public Vector2 size;    //감지 범위
    public LayerMask whatIsPlayer;  //감지할 대상

    int dialogueIndex = 0;
    Dialogue_List otherscript;

    Scene_Change sceneName;
    private string previousBgKey = "previousBg"; // PlayerPrefs 키 값 - 감정


    // Start is called before the first frame update
    void Start()
    {
        GetDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        playerDeceted = Physics2D.OverlapBox(NPCPos.position, size, 0, whatIsPlayer);
        //Debug.Log("playerDeceted : " + playerDeceted);

        if (playerDeceted == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                DisplayNextDialogue();
            }
        }
    }


    //다른 스크립트에서 배열 가져오기
    void GetDialogue()
    {
        // 다른 스크립트의 참조를 얻어옴
        otherscript = FindObjectOfType<Dialogue_List>();

        if (otherscript != null)
        {
            // ScriptB의 배열 가져오기
            dialogueArray = otherscript.GetArray(listIndex);
        }
        else
        {
            Debug.Log("Wrong");
        }
    }

    //가져온 배열 보여주기
    void DisplayNextDialogue()
    {
        if (dialogueIndex < dialogueArray.GetLength(0))
        {
            NextF.SetActive(true);
            dialogueText.text = dialogueArray[dialogueIndex] as string;
            dialogueIndex++;
        }
        else
        {
            NextF.SetActive(false);
            dialogueText.text = "";

            sceneName = FindObjectOfType<Scene_Change>();
            string previousBg = PlayerPrefs.GetString(previousBgKey);   //previousBgKey 키 값에 저장된 값 불러오기 - 감정상태

            if (sceneName.currentScene == "Home" && previousBg == "sad")
            {
                PlayerPrefs.SetString(previousBgKey, "happy");   //행복한 상태
            }
        }
    }

}
