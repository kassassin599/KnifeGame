using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonDontDestroyOnLoad : MonoBehaviour
{
  public bool isLose;

  // Start is called before the first frame update
  void Start()
    {
    if (GameObject.FindGameObjectsWithTag("Mcont").Length == 1)
    {
      DontDestroyOnLoad(this.gameObject);
    }
    else
    {
      Destroy(gameObject);
    }
  }
}
