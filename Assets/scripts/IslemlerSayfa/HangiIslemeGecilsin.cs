using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class HangiIslemeGecilsin : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        
        
            panel.GetComponent<CanvasGroup>().DOFade(1,1f); //
            panel.GetComponent<RectTransform>().DOScale(1,1f).SetEase(Ease.OutSine);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hangiislemacilsin(string hangiislem)
    {
        if (PlayerPrefs.GetInt("sesdurumu")==1)
        {
            audioSource.PlayOneShot(audioClip); 
        }
        PlayerPrefs.SetString("hangiislem",hangiislem);
        SceneManager.LoadScene("ikincimenu");
    }
    

    
    
    public void geridon()
    {
        if (PlayerPrefs.GetInt("sesdurumu")==1)
        {
            audioSource.PlayOneShot(audioClip); 
        }
        SceneManager.LoadScene("MenuLevel");
    }
}
