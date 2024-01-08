using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeB : MonoBehaviour
{

  public float speed = 5f;
  public Rigidbody rb;
  public bool onBarrel;
  public KnifeSpawnB spawn;

  [SerializeField]
  bool isKnifeA;

  private void OnEnable()
  {
    spawn.KnifeBButton.onClick.AddListener(ButtonClick);
  }

  // Use this for initialization
  void Start()
  {

    onBarrel = false;
    rb = GetComponent<Rigidbody>();
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
        rb.velocity = new Vector3(0, -speed, 0);
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Barrel")
    {
      Debug.Log("object name : "+ gameObject.name);
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
    spawn.KnifeBButton.onClick.RemoveListener(ButtonClick);
  }
}
