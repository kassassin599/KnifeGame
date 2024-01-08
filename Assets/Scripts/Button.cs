using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour
{
  public GameObject menucont;
  public MenuController mc;
  public Interstitial interstitialAd;
  public Banner bannerAd;

  // Use this for initialization
  void Start()
  {
    menucont = GameObject.Find("MenuController");
    mc = menucont.GetComponent<MenuController>();
    interstitialAd.LoadAd();
  }

  // Update is called once per frame
  void Update()
  {

    gameObject.transform.Rotate(new Vector3(0, 0, 0.2f));

  }
  //private void OnMouseDown()
  //{
  //  if (gameObject.name == "Play")
  //  {
  //    bannerAd.LoadBanner();
  //    bannerAd.ShowBannerAd();
  //    SceneManager.LoadScene("Game");
  //  }
  //  if (gameObject.name == "Restart")
  //  {
  //    interstitialAd.ShowAd();
  //    mc.isLose = false;
  //  }
  //}
}
