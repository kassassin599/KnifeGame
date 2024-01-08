using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Advertisements.Advertisement;

public class MenuController : MonoBehaviour
{
  public Interstitial interstitialAd;
  public Banner bannerAd;

  public TextMeshProUGUI highScore;
  public GameObject menuCanvas;
  public GameObject loseCanvas;

  private SingletonDontDestroyOnLoad singleton;

  private void OnEnable()
  {
    singleton = FindObjectOfType<SingletonDontDestroyOnLoad>();
    CheckMenu();
  }

  private void CheckMenu()
  {
    if (singleton.isLose == true)
    {
      menuCanvas.gameObject.SetActive(false);
      loseCanvas.gameObject.SetActive(true);
    }
    else
    {
      menuCanvas.gameObject.SetActive(true);
      loseCanvas.gameObject.SetActive(false);
    }
  }

  // Use this for initialization
  void Start()
  {
    
    interstitialAd.LoadAd();

    int a = PlayerPrefs.GetInt("Hscore");
    int b = PlayerPrefs.GetInt("HscoreB");

    highScore.text = "HIGH SCORE - " + (a > b ? a.ToString(): b.ToString());

  }

  public void OnPlayButtonPressed()
  {
    bannerAd.LoadBanner();
    bannerAd.ShowBannerAd();
    SceneManager.LoadScene("Game");
  }
  public void OnMenuButtonPressed()
  {
    interstitialAd.ShowAd();
    singleton.isLose = false;
    CheckMenu();
  }
}
