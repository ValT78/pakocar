using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    

    public void Jouer()
    {
        SceneManager.LoadScene(1);
    }

    public void Quitter()
    {
        Debug.Log("Quitter");
        Application.Quit();
    }
}
