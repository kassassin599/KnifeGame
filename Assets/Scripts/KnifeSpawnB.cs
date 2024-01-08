using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeSpawnB : MonoBehaviour
{

  public GameObject knife;
  public bool isKnife;
  public bool mustNew;
  public GameObject parentObject;
  public TMPro.TextMeshProUGUI CScore;
  public int currScore;
  public SingletonDontDestroyOnLoad mc;
  public GameObject menucont;
  [SerializeField]
  public GameObject ResultPanel;

  [SerializeField]
  bool isKnifeA;

  [SerializeField]
  public UnityEngine.UI.Button KnifeAButton;
  [SerializeField]
  public UnityEngine.UI.Button KnifeBButton;
  // Use this for initialization
  void Start()
  {
    currScore = 0;
    isKnife = true;
    mustNew = false; 
    mc = FindObjectOfType<SingletonDontDestroyOnLoad>();
  }

  // Update is called once per frame
  void Update()
  {
    //if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
    //{
    //  isKnife = false;
    //}
    if (isKnife == false && mustNew == true)
    {

      GameObject childObject = Instantiate(knife, transform.position, transform.rotation);
      childObject.transform.parent = parentObject.transform;
      childObject.transform.localScale = new Vector3(1, 1, 1);
      isKnife = true;
      mustNew = false;
    }
    CScore.text = currScore.ToString();
  }

  public void ButtonClick()
  {
    isKnife = false;
  }

  public void YouLoose()
  {
    Debug.Log("You Lose");
    if (currScore >= PlayerPrefs.GetInt("HscoreB"))
    {
      PlayerPrefs.SetInt("HscoreB", currScore);
      Debug.Log("New: " + PlayerPrefs.GetInt("HscoreB").ToString());
    }
    mc.isLose = true;
    ResultPanel.SetActive(true);
    Time.timeScale = 0f;
  }

  public void LoadMainMenu()
  {
    Time.timeScale = 1.0f;

    SceneManager.LoadScene("Menu");
  }
}
