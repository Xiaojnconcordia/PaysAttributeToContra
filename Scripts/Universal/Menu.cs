using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private bool isPaused;
    public GameObject targetMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPause();
    }

    public void QuitGame()
    {        
        Application.Quit();
    }

    public void ResumeGame()
    {
        isPaused = false;
        gameObject.SetActive(false);
        Time.timeScale = 1;        
    }

    public void PlayAgain()
    {
        Debug.Log("button play again");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void CheckPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("esc");
            if (isPaused)
            {
                isPaused = false;
                targetMenu.SetActive(false);
                Time.timeScale = 1;                
            }
            else
            {
                isPaused = true;
                targetMenu.SetActive(true);
                Time.timeScale = 0;                
            }
        }
    }
}
