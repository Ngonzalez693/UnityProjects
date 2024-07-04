using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controles : MonoBehaviour
{
    public float velocidad;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private bool mirandoDerecha = true;
    public float fuerzaSalto;
    public LayerMask capaPiso;
    public int maxSaltos;
    private int saltosRestantes;
    private Animator animator;
    public AudioClip sonidoSalto;

    private void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosRestantes = maxSaltos;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        Movimiento();
        Salto();
        ReiniciarEscena();
    }

    bool EstaEnPiso(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.000001f, capaPiso);
        return raycastHit.collider != null; // Asegúrate de comprobar si el collider no es nulo
    }

    void Salto(){
        if(EstaEnPiso()){ // Aquí es donde invocamos el método
            saltosRestantes = maxSaltos;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && saltosRestantes > 0 ){

            saltosRestantes--;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            AudioManager.Instance.ReproducirSonido(sonidoSalto);
        }
    }

    void Movimiento(){
        float inputMovimiento = Input.GetAxis("Horizontal");

        if (inputMovimiento != 0f){
            animator.SetBool("isRunning", true);
        }
        else{
            animator.SetBool("isRunning", false);
        }

        rigidbody.velocity = new Vector2(inputMovimiento * velocidad, rigidbody.velocity.y);
        Direccion(inputMovimiento);
    }

    void Direccion(float inputMovimiento){

        if ((mirandoDerecha == true && inputMovimiento < 0)||(mirandoDerecha == false && inputMovimiento > 0)){
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
        }
    }

    void ReiniciarEscena(){
        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
