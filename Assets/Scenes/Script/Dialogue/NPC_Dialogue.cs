using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_Dialogue : MonoBehaviour
{
    public object[] dialogueArray; //������ �迭
    public TMP_Text dialogueText; //��� �����ִ� ��
    public int listIndex;   //������ ���

    public GameObject NextF;    //���� �ؽ�Ʈ

    private bool playerDeceted; //���� ���� Ȯ��
    public Transform NPCPos;   //���� �߽� ��ġ
    public Vector2 size;    //���� ����
    public LayerMask whatIsPlayer;  //������ ���

    int dialogueIndex = 0;
    Dialogue_List otherscript;

    Scene_Change sceneName;
    private string previousBgKey = "previousBg"; // PlayerPrefs Ű �� - ����


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


    //�ٸ� ��ũ��Ʈ���� �迭 ��������
    void GetDialogue()
    {
        // �ٸ� ��ũ��Ʈ�� ������ ����
        otherscript = FindObjectOfType<Dialogue_List>();

        if (otherscript != null)
        {
            // ScriptB�� �迭 ��������
            dialogueArray = otherscript.GetArray(listIndex);
        }
        else
        {
            Debug.Log("Wrong");
        }
    }

    //������ �迭 �����ֱ�
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
            string previousBg = PlayerPrefs.GetString(previousBgKey);   //previousBgKey Ű ���� ����� �� �ҷ����� - ��������

            if (sceneName.currentScene == "Home" && previousBg == "sad")
            {
                PlayerPrefs.SetString(previousBgKey, "happy");   //�ູ�� ����
            }
        }
    }

}
