using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CizgiCiz : MonoBehaviour
{
    public GameObject LinePrefab;
    public GameObject Cizgi;

    public LineRenderer lineRenderer;
    public EdgeCollider2D EdgeCollider;
    public List<Vector2> ParmakPozisyonListesi;
    public List<GameObject> Cizgiler;
    bool CizmekMumkunmu;
    int MaksimumCizgi;
    public TextMeshProUGUI CizgiHakki;

    private void Start()
    {
        CizmekMumkunmu = false;
        MaksimumCizgi = 3;
        CizgiHakki.text = MaksimumCizgi.ToString();
    }
    void Update()
    {
        if (CizmekMumkunmu&& MaksimumCizgi != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CizgiOlustur();
            } 

            if (Input.GetMouseButton(0))
            {
                Vector2 ParmakPozisyonu = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Vector2.Distance(ParmakPozisyonu, ParmakPozisyonListesi[ParmakPozisyonListesi.Count - 1]) > .1f)
                {
                    CizgiyiGuncelle(ParmakPozisyonu);
                }
            }
        }
        if (Cizgiler.Count!=0&&MaksimumCizgi!=0)
        {
            if (Input.GetMouseButtonUp(0))
            {
                MaksimumCizgi--;
                CizgiHakki.text = MaksimumCizgi.ToString();
            }
        }
        
        
    }
    void CizgiOlustur()
    {
        
        

       
        Cizgi = Instantiate(LinePrefab, Vector2.zero, Quaternion.identity);
        Cizgiler.Add(Cizgi);                 
        lineRenderer = Cizgi.GetComponent<LineRenderer>();
        EdgeCollider = Cizgi.GetComponent<EdgeCollider2D>();
        ParmakPozisyonListesi.Clear();
        ParmakPozisyonListesi.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        ParmakPozisyonListesi.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, ParmakPozisyonListesi[0]);
        lineRenderer.SetPosition(1, ParmakPozisyonListesi[1]);
        EdgeCollider.points = ParmakPozisyonListesi.ToArray();

        
        
    }
    void CizgiyiGuncelle(Vector2 GelenParmakPozisyonu)
    {
        ParmakPozisyonListesi.Add(GelenParmakPozisyonu);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1,GelenParmakPozisyonu);
        EdgeCollider.points = ParmakPozisyonListesi.ToArray();
    }
    public void DevamEt()
    {
        foreach (var item in Cizgiler)
        {
            Destroy(item.gameObject);
        }
        Cizgiler.Clear(); 
        MaksimumCizgi = 3;
        CizgiHakki.text = MaksimumCizgi.ToString();
    }
    public void CizmeyiDurdur()
    {
        CizmekMumkunmu = false;
        
    }
    public void CizmeyiBaslat()
    {
        MaksimumCizgi = 3; 
        CizmekMumkunmu = true;
        
    }
}
