using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUiManager : MonoBehaviour
{
    [SerializeField] private Text _win_loose;
   

    public void Start()
    {
            if (Ball_Movement.instance.score>=200)
            {
                _win_loose.text = "You Win";
            }
            else
                _win_loose.text = "You Loose";
        
    }

    public void OnClick_RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
