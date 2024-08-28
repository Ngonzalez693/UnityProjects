using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject faceHolder;
    public GameObject photo;
    public GameObject dialoguePaper;
    public GameObject message;

     private string currentSceneName;

    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(ShowMessageSequence());
    }

    IEnumerator ShowMessageSequence()
    {
        switch (currentSceneName)
        {
            case "Stark":
                yield return ShowStarkMessages();
                break;
            case "Targaryen":
                yield return ShowTargaryenMessages();
                break;
            case "Lannister":
                yield return ShowLannisterMessages();
                break;
        }
    }

    IEnumerator ShowStarkMessages()
    {
        dialogueText.text = "Hay un Salvaje en nuestras tierras, ¡Buscalo!";
        ShowAllMessages();
        yield return new WaitForSeconds(4f);

        dialogueText.text = "Usa las FLECHAS para moverte";
        yield return new WaitForSeconds(4f);

        HideAllMessages();
    }

    IEnumerator ShowTargaryenMessages()
    {
        dialogueText.text = "Un ladrón robo un huevo de dragon, !Traelo de vuelta¡";
        ShowAllMessages();
        yield return new WaitForSeconds(4f);

        dialogueText.text = "Usa las FLECHAS para moverte";
        yield return new WaitForSeconds(4f);

        HideAllMessages();
    }

    IEnumerator ShowLannisterMessages()
    {
        dialogueText.text = "Mi Lord un bandido ha robado mi oro, ¡Recuperalo!";
        ShowAllMessages();
        yield return new WaitForSeconds(4f);

        dialogueText.text = "Usa las FLECHAS para moverte";
        yield return new WaitForSeconds(4f);

        HideAllMessages();
    }


    public void ShowAreaReachedMessage()
    {
        StartCoroutine(ShowAreaMessage());
    }

    IEnumerator ShowAreaMessage()
    {
        switch (currentSceneName)
        {
            case "Stark":
                dialogueText.text = "Ahi esta, ve rapido. Usa ESPACIO para atacar";
                break;
            case "Targaryen":
                dialogueText.text = "Siento un dragon cerca. Usa ESPACIO para atacar";
                break;
            case "Lannister":
                dialogueText.text = "Es el, pídelo amablemente. Usa ESPACIO para atacar";
                break;
        }

        ShowAllMessages();
        yield return new WaitForSeconds(5f);
        HideAllMessages();
    }

    public void ShowEnemyDefeatedMessage()
    {
        StartCoroutine(ShowEnemyMessage());
    }

    IEnumerator ShowEnemyMessage()
    {
        switch (currentSceneName)
        {
            case "Stark":
                dialogueText.text = "Amenaza eliminada, bien hecho. El invierno se acerca";
                break;
            case "Targaryen":
                dialogueText.text = "Gracias por recuperar a mi hijo";
                break;
            case "Lannister":
                dialogueText.text = "Gracias por recuperar mi oro mi Lord, un Lannister siempre paga sus deudas";
                break;
        }

        ShowAllMessages();
        yield return new WaitForSeconds(4f);
        HideAllMessages();

        EndLevel();
    }

    void EndLevel()
    {
        AudioManager.instance.StopLevelMusic(); 
        SceneManager.LoadScene("Selector");
    }

    void ShowAllMessages()
    {
        faceHolder.SetActive(true);
        photo.SetActive(true);
        dialoguePaper.SetActive(true);
        message.SetActive(true);
    }

    void HideAllMessages()
    {
        faceHolder.SetActive(false);
        photo.SetActive(false);
        dialoguePaper.SetActive(false);
        message.SetActive(false);
    }
}
