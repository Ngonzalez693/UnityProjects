using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    public void ReiniciarJuego(){
        SceneManager.LoadScene("Juego"); 
    }

    public void SalirAlMenu(){
        SceneManager.LoadScene("Juego");
    }
}
