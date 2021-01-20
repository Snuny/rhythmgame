using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer icon;
    public Sprite defaultIcon;
    public Sprite pressedIcon;

    public KeyCode triggerKey;

    // Start is called before the first frame update
    void Start()
    {
        icon = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(triggerKey))
        {
            icon.sprite = pressedIcon;
            transform.localScale = new Vector3(0.135f, 0.135f, 1f);
        }

        if (Input.GetKeyUp(triggerKey))
        {
            icon.sprite = defaultIcon;
            transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        }
    }
}
