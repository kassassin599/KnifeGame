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

  [SerializeField]
  AudioClip mosquitoAudio;
  [SerializeField]
  AudioClip ammaBhenAudio;
  [SerializeField]
  AudioSource audioSource;
  [SerializeField]
  ParticleSystem bloodParticle;

  SingletonDontDestroyOnLoad mc;

  GameObject butt;

  private void OnEnable()
  {
    spawn.KnifeAButton.onClick.AddListener(ButtonClick);
  }

  // Use this for initialization
  void Start()
  {

    onBarrel = false;

    mc = FindObjectOfType<SingletonDontDestroyOnLoad>();
    if (mc.isLose == true) { return; }

    audioSource.clip = mosquitoAudio;
    audioSource.loop = true;
    audioSource.Play();
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

      GetComponent<Animator>().SetBool("isStuck", true);

      butt = other.gameObject;
      butt.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;

      butt.transform.parent.GetComponent<Animator>().SetTrigger("PlayerA");

      audioSource.Stop();

      Vector3 contactPos = other.ClosestPoint(transform.position);

      bloodParticle.transform.position = contactPos;

      bloodParticle.Play();

      StartCoroutine(ResetColor());
    }
    if (other.tag == "Knife")
    {
      spawn.YouLoose();

      audioSource.clip =ammaBhenAudio; 
      audioSource.loop = false;
      audioSource.Play();
    }
  }

  private IEnumerator ResetColor()
  {
    // Wait for 1 second
    yield return new WaitForSeconds(.1f);
    // Reset the color to white
    butt.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;

    audioSource.Play();
  }

  private void OnDisable()
  {
    spawn.KnifeAButton.onClick.RemoveListener(ButtonClick);
    spawn.KnifeBButton.onClick.RemoveListener(ButtonClick);
  }
}
