using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    // Un int est un nombre
    private int melons = 0;

    [SerializeField] private Text watermelonsText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Sa c'est pour que le code detecte que le personnage a touchee la melon d'eau afin qu'ekke puisse disparaitre
        if (collision.gameObject.CompareTag("Watermelon"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            melons++;
            //Sa c'est pour compter les melons
            watermelonsText.text = "Melons:" + melons;
        }
    }
 
   
}
