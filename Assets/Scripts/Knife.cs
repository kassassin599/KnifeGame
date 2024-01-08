using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Knife : MonoBehaviour
{

  public float speed = 5f;
  public Rigidbody rb;
  public bool onBarrel;
  public Knife_Spawn spawn;

  [SerializeField]
  bool isKnifeA;

  private void OnEnable()
  {
    spawn.KnifeAButton.onClick.AddListener(ButtonClick);
  }

  // Use this for initialization
  void Start()
  {

    onBarrel = false;
  }

  // Update is called once per frame
  void Update()
  {

    //if ((Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && onBarrel == false)
    //{
    //  if (isKnifeA)
    //    rb.velocity = new Vector3(0, speed, 0);
    //  else
    //    rb.velocity = new Vector3(0, -speed, 0);
    //}

  }

  public void ButtonClick()
  {
    if (onBarrel == false)
    {
      if (isKnifeA)
        rb.velocity = new Vector3(0, speed, 0);
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Barrel")
    {
      spawn.currScore++;
      gameObject.transform.SetParent(other.transform);
      rb.velocity = Vector3.zero;
      this.onBarrel = true;
      spawn.mustNew = true;
      rb.detectCollisions = false;
    }
    if (other.tag == "Knife")
    {
      spawn.YouLoose();
    }
  }
  private void OnDisable()
  {
    spawn.KnifeAButton.onClick.RemoveListener(ButtonClick);
    spawn.KnifeBButton.onClick.RemoveListener(ButtonClick);
  }
}
