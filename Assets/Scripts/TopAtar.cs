using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopAtar : MonoBehaviour
{
    
    [SerializeField] private GameObject[] KovaNoktalari; 
    [SerializeField] private GameObject[] Toplar;
    [SerializeField] private GameObject TopAtarMerkezi;
    [SerializeField] private GameObject Kova;
    int AktifTopIndex;
    int RandomKovaIndex;
    bool Kilit;
    int AtilanTopSayisi;

    public void OyunBaslasin()
    {
        StartCoroutine(TopAtisSistemi());
    }
    IEnumerator TopAtisSistemi()
    {
        while (true)
        {
            if (!Kilit)
            {
                yield return new WaitForSeconds(.5f);
                Toplar[AktifTopIndex].transform.position = TopAtarMerkezi.transform.position;
                Toplar[AktifTopIndex].SetActive(true);
                
                
                Toplar[AktifTopIndex].GetComponent<Rigidbody2D>().AddForce(PozisyonVer(AciVer(70f,110f )) * 750);
                AtilanTopSayisi = 1;
                if (AktifTopIndex != Toplar.Length - 1)
                {
                    AktifTopIndex++;
                }
                else
                {
                    AktifTopIndex = 0;
                }
                yield return new WaitForSeconds(.7f);
                RandomKovaIndex = Random.Range(0, KovaNoktalari.Length - 1);
                Kova.transform.position = KovaNoktalari[RandomKovaIndex].transform.position;
                Kova.SetActive(true);
                Kilit = true;
                Invoke("TopuKontrolEt", 10f);

            }
            else
            {
                yield return null;
            }
        }
    }
    public void DevamEt()
    {
        if (AtilanTopSayisi==1)
        {
         Kilit = false;
         Kova.SetActive(false);
         CancelInvoke();
        }
        else
        {
            AtilanTopSayisi--;
        }
      
    }
    public void TopAtmaDurdur()
    {
        StopAllCoroutines();
    }
   float AciVer(float deger1,float deger2)
    {
        return Random.Range(deger1, deger2);
    }
    Vector3 PozisyonVer(float GelenAci)
    {
        return Quaternion.AngleAxis(GelenAci, Vector3.forward) * Vector3.right;
    }
    void TopuKontrolEt()
    {
        if (Kilit)
        {
            GetComponent<GameManager>().OyunBitti(); 
        }

    }






}



   

 

