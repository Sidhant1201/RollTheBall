using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameplay_UI_Manager : MonoBehaviour
{
   
    public Text scoreText;

    #region pause menu
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    #endregion

    // Start is called before the first frame update

    private void Start()
    {
        scoreText.text = "Score:" + 0;
    }
   /* private void Update()
    {
        
    }*/

    public void OnClick_PauseMenu()
    {
        if (!gameIsPaused)
            pause();
    }

    public void resume()
    {

        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1f;
    }

    void pause()
    {
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene(0);
    }
    public void QuitMenu()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene(2);
    }
}
