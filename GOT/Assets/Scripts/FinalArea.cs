using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalArea : MonoBehaviour
{
    public LevelSystem levelSystem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            levelSystem.ShowAreaReachedMessage();
            gameObject.SetActive(false);
        }
    }
}
