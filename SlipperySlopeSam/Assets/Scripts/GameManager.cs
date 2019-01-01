using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    static GameManager instance = null;

    public static GameManager getInstance() { return instance; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        //for reload scene
        DontDestroyOnLoad(gameObject);
    }

    void Update () {
        if (Input.GetButtonDown("R"))
        {
            Restart();
        }
	}

    public void StartMenu()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RageQuit()
    {
        Application.Quit();
    }

    public void Level(string name)
    {
        SceneManager.LoadScene(name);
    }
}
