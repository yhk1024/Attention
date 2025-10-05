using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Street_Dialogue : MonoBehaviour
{
    public object[] dialogueArray; //������ �迭
    public TMP_Text dialogueText; //��� �����ִ� ��
    public int listIndex;   //������ ���
    int dialogueIndex = 0;  //������ ��� ����
    Dialogue_List listScript;  //��簡 ����� ��ũ��Ʈ

    public GameObject NextF;    //���� �ؽ�Ʈ

    string previousScene = "";  //PlayerPrefs ���� ������ ����
    private string previousSceneKey = "PreviousScene"; // PlayerPrefs Ű �� - ��


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


    //�ٸ� ��ũ��Ʈ���� �迭 ��������
    void GetDialogue()
    {
        // �ٸ� ��ũ��Ʈ�� ������ ����
        listScript = FindObjectOfType<Dialogue_List>();

        if (listScript != null)
        {
            // Dialogue_ListB�� �迭 ��������
            dialogueArray = listScript.GetArray(listIndex);
        }else
        {
            Debug.Log("Wrong");
        }
    }

    //�迭�� ���� ������ ������
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
