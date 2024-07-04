using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    public int valor = 1;
    public AudioClip coinSFX; 

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.CompareTag("Player")){
            GameManager.Instance.SumarMonedas(valor);
            Destroy(this.gameObject);
            AudioManager.Instance.ReproducirSonido(coinSFX);
        }
    }
}