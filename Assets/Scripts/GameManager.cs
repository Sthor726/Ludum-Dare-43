using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }

    public int currentSceneIndex;
    public Animator panelAnim;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            FailedLevel();
        }
    }

    public void EndLevel()
    {
        panelAnim.SetInteger("Scene", 1);
    }
    public void FailedLevel()
    {
        panelAnim.SetInteger("Scene", 2);
    }
    public void LoadNext()
    {
        if(currentSceneIndex == 4)
        {
            Destroy(GameObject.Find("Music"));
        }
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void Reload()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
}
