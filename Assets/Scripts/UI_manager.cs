using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_manager : MonoBehaviour
{
    #region on_click methods
    public void Onclick_playGameButton()
    {
        SceneManager.LoadScene(1);

    }

    public void Onclick_Instructions()
    {
        SceneManager.LoadScene(4);
    }

    #endregion
}
