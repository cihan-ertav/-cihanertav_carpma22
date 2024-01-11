using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;



public class TimerManeger : MonoBehaviour
{
    [SerializeField] private Slider timeSlider; // Süre çubuğu
    [SerializeField] private Text sureText;
    [SerializeField] private GameObject sonucPanel;
    [SerializeField] private GameObject zamanresim, dogruyalisresim, puanpanel, player, sonuclar, canvas, slider;
    [SerializeField] private Color startColor = Color.green; // Başlangıç rengi
    [SerializeField] private Color middleColor = Color.yellow; // Orta nokta rengi
    [SerializeField] private Color endColor = Color.red; // Bitiş rengi

    int kalanSure;
    
    bool suresayiyormu;
    
    //private int totalTime = 60; // Toplam süre
    private float currentTime; // Geçen süre
    //private bool isCounting = true; // Süre sayılıyor mu?
    // Start is called before the first frame update
    void Start()
    {
        kalanSure = 90;
        suresayiyormu = true;
        sonucPanel.SetActive(false);
        
        
        zamanresim.SetActive(true);
        dogruyalisresim.SetActive(true);
        puanpanel.SetActive(true);
        player.SetActive(true);
        sonuclar.SetActive(true);
        canvas.SetActive(true);
        slider.SetActive(true);
        
        // Başlangıç rengini ayarla
        timeSlider.fillRect.GetComponent<Image>().color = startColor;
        

        StartCoroutine(sureyiBaslat());

    }
    
    IEnumerator sureyiBaslat()
    {
        while (suresayiyormu)
        {
            yield return new WaitForSeconds(1f);

            if (kalanSure < 10)
            {
                sureText.text = "0" + kalanSure.ToString();
            }
            else
            {
                sureText.text = kalanSure.ToString();
            }
            
            // Süre çubuğunu güncelle
            timeSlider.value = (float)kalanSure / 90f; // 20 saniye süre için
            
            UpdateColorTransition();

            if (kalanSure<=0)
            {
                suresayiyormu = false;
                sureText.text = "";
                ekraniTemizle();
                sonucPanel.SetActive(true);
            }
            kalanSure--;
        }
        
        
    }
    
    void ekraniTemizle()
    {
        zamanresim.SetActive(false);
        dogruyalisresim.SetActive(false);
        puanpanel.SetActive(false);
        player.SetActive(false);
        sonuclar.SetActive(false);
        canvas.SetActive(false);
        slider.SetActive(false);
    }
    
    void UpdateColorTransition()
    {
        // Renk geçişini hesapla (0-1 aralığında bir değer)
        float colorTransition = Mathf.Clamp01((float)kalanSure / 90f);

        // Renkleri Lerp fonksiyonu ile geçiş yaparak belirle
        timeSlider.fillRect.GetComponent<Image>().color = Color.Lerp(startColor, endColor, 1 - colorTransition);
        //timeSlider.fillRect.GetComponent<Image>().color = Color.Lerp(startColor, middleColor, 1 - colorTransition);
        //timeSlider.fillRect.GetComponent<Image>().color = Color.Lerp(middleColor, endColor, 1 - colorTransition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
