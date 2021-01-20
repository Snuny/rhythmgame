using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundShift : MonoBehaviour
{
    public AudioSource trackOne;
    public Material morning, night, rave;
    private bool firstChange, secondChange, thirdChange;
    private float fadeSpeed;
    Renderer current;

    // Start is called before the first frame update
    void Start()
    {
        current = GetComponent<Renderer>();
        fadeSpeed = 0.2f;
        firstChange = true;
        secondChange = true;
        thirdChange = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (trackOne.isPlaying && trackOne.time > 42.0f)
        {
            if (firstChange == true)
            {
                FadeOut();
                Invoke("MorningChange", 5f);
            }
            if (trackOne.time < 47.0f)
            {
                Invoke("FadeIn", 5.1f);
            }
        }

        if (trackOne.isPlaying && trackOne.time > 89.0f)
        {
            if (secondChange == true)
            {
                FadeOut();
                Invoke("NightChange", 5f);
            }
            if (trackOne.time < 94.0f)
            {
                Invoke("FadeIn", 5.1f);
            }
        }

        if (trackOne.isPlaying && trackOne.time > 136.0f)
        {
            if (thirdChange == true)
            {
                FadeOut();
                Invoke("RaveChange", 5f);
            }
            if (trackOne.time < 141.0f)
            {
                Invoke("FadeIn", 5.1f);
            }
        }
    }

    void FadeOut()
    {
        Debug.Log("FadeOut");
        Color color = this.GetComponent<MeshRenderer>().material.color;
        color.a -= fadeSpeed * Time.deltaTime;
        this.GetComponent<MeshRenderer>().material.color = color;
    }

    void FadeIn()
    {
        Debug.Log("FadeIn");
        Color color = this.GetComponent<MeshRenderer>().material.color;
        color.a += fadeSpeed * Time.deltaTime;
        this.GetComponent<MeshRenderer>().material.color = color;
    }

    void MorningChange()
    {
        Debug.Log("Change to Morning");
        Debug.Log("First Change");
        if (firstChange == true)
        {
            current.material = morning;
            firstChange = false;
        }
    }

    void NightChange()
    {
        Debug.Log("Change to Night");
        Debug.Log("Second Change");
        if (secondChange == true)
        {
            current.material = night;
            secondChange = false;
        }
    }

    void RaveChange()
    {
        Debug.Log("Change to Rave");
        Debug.Log("Third Change");
        if (thirdChange == true)
        {
            current.material = rave;
            thirdChange = false;
        }
    }

}
