using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open : MonoBehaviour
{
    [SerializeField] private string sceneName;  //�̵��� ȭ�� �̸�

    private bool playerDeceted; //���� ���� Ȯ��
    public Transform doorPos;   //���� �߽� ��ġ
    public Vector2 size;    //���� ����
    public LayerMask whatIsPlayer;  //������ ���

    Scene_Change sceneChange;   //�ٸ� ��ũ��Ʈ

    private string previousSceneKey = "PreviousScene"; // PlayerPrefs Ű �� - ȭ��
    private string previousBgKey = "previousBg"; // PlayerPrefs Ű �� - ����
    string previousBg;


    // Start is called before the first frame update
    void Start()
    {
        sceneChange = FindObjectOfType<Scene_Change>(); //�ٸ� ��ũ��Ʈ �ҷ�����

        previousBg = PlayerPrefs.GetString(previousBgKey);   //previousBgKey Ű ���� ����� �� �ҷ����� - ��������
    }

    // Update is called once per frame
    void Update()
    {
        playerDeceted = Physics2D.OverlapBox(doorPos.position, size, 0, whatIsPlayer);  //���� �ȿ� �÷��̾ ���� ���

        if (playerDeceted == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                sceneChange.SceneChange(sceneName);
                // ���� �� ���� ��������
                string previousScene = PlayerPrefs.GetString(previousSceneKey);
                Debug.Log("open ���� ��: " + previousScene);

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
