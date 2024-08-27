using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlSelectorControlller : MonoBehaviour
{
    public void StarkLevel()
    {
        SceneManager.LoadScene("Stark");
    }
    
    public void TargaryenLevel()
    {
        SceneManager.LoadScene("Targaryen");
    }

    public void LannisterLevel()
    {
        SceneManager.LoadScene("Lannister");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
