using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change : MonoBehaviour
{
    public static string prevScene;
    public string currentScene;

    private string previousSceneKey = "PreviousScene"; // PlayerPrefs Ű �� - ȭ��
    

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;

        // ���� �� ���� ��������
        string previousScene = PlayerPrefs.GetString(previousSceneKey);
        Debug.Log("change ���� ��: " + previousScene);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SceneChange(string sceneName)
    {
        prevScene = currentScene;
        SceneManager.LoadScene(sceneName);

        // ���� ���� ���� ������ ����
        PlayerPrefs.SetString(previousSceneKey, currentScene);
        Debug.Log("change ���� ��: " + currentScene);
    }
}
