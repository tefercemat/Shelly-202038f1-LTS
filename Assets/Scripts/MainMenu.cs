using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private string newGameScene = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        if (newGameScene != null) {
            SceneManager.LoadScene(newGameScene);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
