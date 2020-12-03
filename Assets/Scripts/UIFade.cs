using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{

    public Image fadeScreen;

    private bool shouldFadeOut;
    private bool shouldFadeIn;

    public float fadeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldFadeOut)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime)); //1 = 255 | 0 = 0

            if(fadeScreen.color.a == 1f)
            {
                shouldFadeOut = false;
            }
        }

        if(shouldFadeIn)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if(fadeScreen.color.a == 0f)
            {
                shouldFadeIn = false;
            }
        }
    }

    public void FadeToBlack()
    {
        shouldFadeOut = true;
        shouldFadeIn = false;
    }
    public void FadeFromBlack()
    {
        shouldFadeOut = false;
        shouldFadeIn = true;
    }
}
