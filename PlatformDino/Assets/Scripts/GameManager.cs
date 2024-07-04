using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int NumMonedas { get { return numMonedas; } }
    private int numMonedas;

    public float tiempoRestante = 30f; 
    private bool juegoTerminado = false;
    private int totalMonedas; 
    public GameObject mensajeFinal; 

    void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Debug.Log("Más de un GameManager en escena");
            Destroy(gameObject);
        }
    }

    void Start(){
        
        totalMonedas = FindObjectsOfType<Coins>().Length;
        if (mensajeFinal != null){
            mensajeFinal.SetActive(false); 
        }
    }

    void Update(){
        if (!juegoTerminado){
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante <= 0){
                tiempoRestante = 0;
                TerminarJuego(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.R)){
            ResetGame();
        }
    }

    public void SumarMonedas(int monedasSuma){
        numMonedas += monedasSuma;
        if (numMonedas >= totalMonedas){
            TerminarJuego(true);
        }
    }

    public void TerminarJuego(bool ganaste){
        juegoTerminado = true;
        Time.timeScale = 0f;
        AudioManager.Instance.PausarMusica();
        
        if (mensajeFinal != null){
            mensajeFinal.SetActive(true);
            TextMeshProUGUI textoMensaje = mensajeFinal.GetComponent<TextMeshProUGUI>();
            if (ganaste){
                textoMensaje.text = "¡Ganaste!\nPulsa 'R' para Reiniciar";
            } else {
                 
                textoMensaje.text = "¡Perdiste!\nPulsa 'R' para Reiniciar";
            }
        }
    }

    public void ResetGame(){
        juegoTerminado = false;
        Time.timeScale = 1f; 
        numMonedas = 0;
        tiempoRestante = 30f;
        AudioManager.Instance.ReiniciarMusica(); 
        if (mensajeFinal != null){
            mensajeFinal.SetActive(false);
        }
        
        SceneManager.LoadScene("Juego");
    }
}
