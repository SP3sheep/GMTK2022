using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public int firstLevelIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(firstLevelIndex);
    }

    public void LoadOptions()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        SceneManager.LoadScene("Options Scene");
    }

    public void LoadCredits()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        SceneManager.LoadScene("Credits Scene");
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        Application.Quit();
    }
}
