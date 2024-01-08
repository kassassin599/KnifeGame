using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultPanel : MonoBehaviour
{
  string WIN_TEXT = "YOU WIN";
  string LOSE_TEXT = "YOU LOSE";

  [SerializeField]
  TextMeshProUGUI textButtonA;
  [SerializeField]
  TextMeshProUGUI textButtonB;
  [SerializeField]
  TextMeshProUGUI textScoreA;
  [SerializeField]
  TextMeshProUGUI textScoreB;

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
    }
    else
    {
      textButtonA.text = LOSE_TEXT;
      textButtonB.text = WIN_TEXT;
    }
  }
}
