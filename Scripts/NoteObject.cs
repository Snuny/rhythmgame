using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    private bool canBePressed;
    AudioSource missSound;
    public AudioClip hitSound;
    public KeyCode triggerKey;
    public GameObject normalEffect, goodEffect, perfectEffect, missEffect;

    // Start is called before the first frame update
    void Start()
    {
        canBePressed = false;
        missSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(triggerKey))
        {
            if (canBePressed)
            {
                //GameManager.instance.NoteHit();
                //Destroy(gameObject);
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
                gameObject.SetActive(false);

                if (Mathf.Abs(transform.position.x) > 0.085f)
                {
                    Debug.Log("Normal");
                    GameManager.instance.NormalHit();
                    Instantiate(normalEffect, transform.position, normalEffect.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.x) > 0.05f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, normalEffect.transform.rotation);
                }
                else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, normalEffect.transform.rotation);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*if (collision.tag == "Activator")
        {
            canBePressed = false;
            GameManager.instance.NoteMissed();
        }*/
        //check if the player is pressing the button on the frame the arrow disappears

        if (Input.GetKeyDown(triggerKey))
        {
            if (collision.tag == "Activator")
            {
                canBePressed = true;
            }
        }

        else
        {
            if (collision.tag == "Activator")
            {
                missSound.Play();
                canBePressed = false;
                GameManager.instance.NoteMissed();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
                Destroy(gameObject, 1f);
            }
        }
    }
}
