using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI puntos;
    public TextMeshProUGUI tiempo;
    public GameObject mensajeFinal; 

    void Start() {
        GameManager.Instance.mensajeFinal = mensajeFinal;
    }

    void Update(){
        if(puntos != null){
            puntos.text = "Monedas: " + GameManager.Instance.NumMonedas.ToString();
        } else {
            Debug.LogError("La referencia de 'puntos' no ha sido asignada en el Inspector.");
        }

        if(tiempo != null){
            tiempo.text = "Tiempo: " + Mathf.Ceil(GameManager.Instance.tiempoRestante).ToString();
        } else {
            Debug.LogError("La referencia de 'tiempo' no ha sido asignada en el Inspector.");
        }
    }
}
