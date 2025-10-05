using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Street_Dialogue : MonoBehaviour
{
    public object[] dialogueArray; //가져올 배열
    public TMP_Text dialogueText; //대사 보여주는 곳
    public int listIndex;   //가져올 대사
    int dialogueIndex = 0;  //가져올 대사 순서
    Dialogue_List listScript;  //대사가 저장된 스크립트

    public GameObject NextF;    //다음 텍스트

    string previousScene = "";  //PlayerPrefs 값을 저장할 변수
    private string previousSceneKey = "PreviousScene"; // PlayerPrefs 키 값 - 씬


    // Start is called before the first frame update
    void Start()
    {
        previousScene = PlayerPrefs.GetString(previousSceneKey);

        if (previousScene == "")
        {
            GetDialogue();
            DisplayNextDialogue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (previousScene == "")
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
        listScript = FindObjectOfType<Dialogue_List>();

        if (listScript != null)
        {
            // Dialogue_ListB의 배열 가져오기
            dialogueArray = listScript.GetArray(listIndex);
        }else
        {
            Debug.Log("Wrong");
        }
    }

    //배열의 값을 가져와 보여줌
    void DisplayNextDialogue()
    {
        if (dialogueIndex < dialogueArray.GetLength(0))
        {
            //NextF.SetActive(true);
            dialogueText.text = dialogueArray[dialogueIndex] as string;
            dialogueIndex++;
        }
        else
        {
            dialogueText.text = "";
            NextF.SetActive(false);
        }
    }
}
