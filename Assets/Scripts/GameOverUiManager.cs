using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUiManager : MonoBehaviour
{
    [SerializeField] private Text _win_loose;
    [SerializeField] private GameObject _nextLevel;
   
   

  public void Start()
  {
     if(Ball_Movement.instance.score>=200 && Ball_Movement.instance.hitExit)
     {
           _win_loose.text = "You Win";
           if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
              _nextLevel.SetActive(true);

     }

     else
     {
            _win_loose.text = "You Loose";
            _nextLevel.SetActive(false);

     }
                
  }


    public void OnClick_RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(3);
    }
}
