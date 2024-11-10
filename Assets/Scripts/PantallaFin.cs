using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaFin : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("Escena"); 
    }

    public void ExitGame()
    {
        Application.Quit();
        //para comprobar que funciona haciendo que salga también del editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
