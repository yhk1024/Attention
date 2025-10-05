using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change : MonoBehaviour
{
    public static string prevScene;
    public string currentScene;

    private string previousSceneKey = "PreviousScene"; // PlayerPrefs 키 값 - 화면
    

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;

        // 이전 씬 정보 가져오기
        string previousScene = PlayerPrefs.GetString(previousSceneKey);
        Debug.Log("change 이전 씬: " + previousScene);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SceneChange(string sceneName)
    {
        prevScene = currentScene;
        SceneManager.LoadScene(sceneName);

        // 현재 씬을 이전 씬으로 저장
        PlayerPrefs.SetString(previousSceneKey, currentScene);
        Debug.Log("change 현재 씬: " + currentScene);
    }
}
