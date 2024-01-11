using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Ikincimenu : MonoBehaviour
{
    
    [SerializeField] private GameObject menupanel;
    [SerializeField] private GameObject toplamaPaneli;
    [SerializeField] private GameObject cikarmaPaneli;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    
    string HangiIslem;
    // Start is called before the first frame update
    void Start()
    {
        /*if (menupanel!=null)//
        {
            menupanel.GetComponent<CanvasGroup>().DOFade(1,1f); //
            menupanel.GetComponent<RectTransform>().DOScale(1,1f).SetEase(Ease.OutSine);
        }*/
        
        kapatpaneller();
        
        if (PlayerPrefs.HasKey("hangiislem"))
        {
            HangiIslem=PlayerPrefs.GetString("hangiislem");
        }

        if (HangiIslem=="toplama")
        {
            
            toplamaPaneli.SetActive(true);
            toplamaPaneli.GetComponent<CanvasGroup>().DOFade(1,1f); //
            toplamaPaneli.GetComponent<RectTransform>().DOScale(1,1f).SetEase(Ease.OutSine);
        }
        else if (HangiIslem=="carpma")
        {
            menupanel.SetActive(true);
            menupanel.GetComponent<CanvasGroup>().DOFade(1,1f); //
            menupanel.GetComponent<RectTransform>().DOScale(1,1f).SetEase(Ease.OutSine);
        }
        else
        {
            cikarmaPaneli.SetActive(true);
            cikarmaPaneli.GetComponent<CanvasGroup>().DOFade(1,1f); //
            cikarmaPaneli.GetComponent<RectTransform>().DOScale(1,1f).SetEase(Ease.OutSine); 
        }
            
        
        
    }
    
    void kapatpaneller()
    {
        menupanel.SetActive(false);
        toplamaPaneli.SetActive(false);
        cikarmaPaneli.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hangioyunacilsin(string hangioyun)
    {
        if (PlayerPrefs.GetInt("sesdurumu")==1)
        {
            audioSource.PlayOneShot(audioClip); 
        }
        PlayerPrefs.SetString("hangioyun",hangioyun);
        SceneManager.LoadScene("GameLevel");
    }
    
    public void hangiToplamaOyunuAcilsin(string hangioyun)
    {
        if (PlayerPrefs.GetInt("sesdurumu")==1)
        {
            audioSource.PlayOneShot(audioClip); 
        }
        PlayerPrefs.SetString("hangitoplama",hangioyun);
        SceneManager.LoadScene("GameLevel");
    }

    public void geriDon()
    {
        if (PlayerPrefs.GetInt("sesdurumu")==1)
        {
            audioSource.PlayOneShot(audioClip); 
        }
        SceneManager.LoadScene("MenuLevel");
    }
    
    
    public void geridonislem()
    {
        if (PlayerPrefs.GetInt("sesdurumu")==1)
        {
            audioSource.PlayOneShot(audioClip); 
        }
        SceneManager.LoadScene("IslemlerSayfa");
    }
}
