using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem Basket;
    [SerializeField] private ParticleSystem BestBasket;
    [SerializeField] private TopAtar _TopAtar;
    [SerializeField] private CizgiCiz _CizgiCiz;
    [SerializeField] private List<AudioSource> Sesler;
    
    [SerializeField] private GameObject[] Paneller;
    [SerializeField] private TextMeshProUGUI[] ScoreTextleri;
    public static int GirenTopSayisi;
    public TextMeshProUGUI CizgiHakki;


    void Start()
    {
        GirenTopSayisi = 0;
        if (PlayerPrefs.HasKey("BestScore"))
        {
            ScoreTextleri[0].text = PlayerPrefs.GetInt("BestScore").ToString();
            ScoreTextleri[1].text = PlayerPrefs.GetInt("BestScore").ToString();
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", 0);
            ScoreTextleri[0].text ="0";
            ScoreTextleri[1].text = "0";
        }
    }

   
    public void DevamEt(Vector2 Pos)
    {

        Basket.transform.position = Pos;
        Basket.gameObject.SetActive(true);
        Basket.Play();


        GirenTopSayisi++;
        Sesler[0].Play();        
        _TopAtar.DevamEt();
        _CizgiCiz.DevamEt();
    }
    public void OyunBitti()
    {
        Paneller[2].SetActive(false);
        Sesler[1].Play();
        Paneller[1].SetActive(true);

       
        
        ScoreTextleri[1].text = PlayerPrefs.GetInt("BestScore").ToString();
        ScoreTextleri[2].text = GirenTopSayisi.ToString();
        if (GirenTopSayisi>PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", GirenTopSayisi);
            BestBasket.gameObject.SetActive(true);
            BestBasket.Play(); 
        }
        _TopAtar.TopAtmaDurdur();
        _CizgiCiz.CizmeyiDurdur();

    }
    public void OyunBaslasin()
    {
        
        Paneller[0].SetActive(false);
        Paneller[2].SetActive(true);
        _TopAtar.OyunBaslasin();
        _CizgiCiz.CizmeyiBaslat();
        

    }
    public void TekrarOyna()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
