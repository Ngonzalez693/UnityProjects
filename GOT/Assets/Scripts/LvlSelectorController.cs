using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlSelectorControlller : MonoBehaviour
{
    public void StarkLevel()
    {
        AudioManager.instance.PlayLevelMusic(1);
        SceneManager.LoadScene("Stark");
    }
    
    public void TargaryenLevel()
    {
        AudioManager.instance.PlayLevelMusic(2);
        SceneManager.LoadScene("Targaryen");
    }

    public void LannisterLevel()
    {
        AudioManager.instance.PlayLevelMusic(3);
        SceneManager.LoadScene("Lannister");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
