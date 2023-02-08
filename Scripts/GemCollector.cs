using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCollector : MonoBehaviour
{
    // Un int est un nombre
    private int gems = 0;

    [SerializeField] private Text gemsText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Sa c'est pour que le code detecte que le personnage a touchee la melon d'eau afin qu'ekke puisse disparaitre
        if (collision.gameObject.CompareTag("gems"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            gems++;
            //Sa c'est pour compter les melons
            gemsText.text = "Gems:" + gems;
        }
    }
 
   
}
