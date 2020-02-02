using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Image img;
    public bool fadingToBlack = true;   // true = fade to black, false = fade to game.
    public bool fadeComplete;           // signal to do stuff.

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        img.color = new Color(0f, 0f, 0f, Mathf.Clamp01(img.color.a));
        if (fadingToBlack && !Mathf.Approximately(img.color.a, 1f))
            img.color = new Color(0f, 0f, 0f, img.color.a + 0.01f);
        else if (!fadingToBlack && !Mathf.Approximately(img.color.a, 0.01f))
            img.color = new Color(0f, 0f, 0f, img.color.a - 0.01f);
        else if ((fadingToBlack && Mathf.Approximately(img.color.a, 1f)) || (!fadingToBlack && Mathf.Approximately(img.color.a, 0f)))
        {
            fadeComplete = true;
        }
    }

    public bool CHECKFADE()
    {
        return fadeComplete || ((fadingToBlack && Mathf.Approximately(img.color.a, 1f)) || (!fadingToBlack && img.color.a < 0.05));
    }
}
