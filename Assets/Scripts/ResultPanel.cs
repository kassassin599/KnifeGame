using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
  string WIN_TEXT = "YOU WIN";
  string LOSE_TEXT = "YOU LOSE";
  string DRAW_TEXT = "DRAW";

  [SerializeField]
  TextMeshProUGUI textButtonA;
  [SerializeField]
  TextMeshProUGUI textButtonB;
  [SerializeField]
  TextMeshProUGUI textScoreA;
  [SerializeField]
  TextMeshProUGUI textScoreB;
  [SerializeField]
  Sprite redLoseButtonImage;

  private void OnEnable()
  {
    string a  = textScoreA.text;
    int aScore;
    int.TryParse(a, out aScore);
    string b  = textScoreB.text;
    int bScore;
    int.TryParse(b, out bScore);

    if (aScore > bScore)
    {
      textButtonA.text = WIN_TEXT;
      textButtonB.text = LOSE_TEXT;
      textButtonB.transform.parent.GetComponent<Image>().sprite = redLoseButtonImage;
    }
    else if(aScore == bScore)
    {
      textButtonA.text = DRAW_TEXT;
      textButtonB.text = DRAW_TEXT;
    }
    else
    {
      textButtonA.text = LOSE_TEXT;
      textButtonA.transform.parent.GetComponent<Image>().sprite = redLoseButtonImage;

      textButtonB.text = WIN_TEXT;
    }
  }
}
