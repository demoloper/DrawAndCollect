using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tops : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;
    [SerializeField] private AudioSource TopSesi;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TopSesi.Play();
        if (collision.gameObject.CompareTag("basket"))
        {
            
            gameObject.SetActive(false);
            _GameManager.DevamEt(transform.position);
        }
        else if (collision.gameObject.CompareTag("OyunBitti"))
        {
           
            _GameManager.OyunBitti();
            gameObject.SetActive(false);
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TopSesi.Play();
    }
    
}
