using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    public string areaToLoad;
    public string areaTransitionName;

    public float waitToLoad = 1f;
    private bool shouldLoadAfterFade;

    public AreaEntrance entrance;

    private UIFade uiFade;

    void Start()
    {
        entrance.transitionName = areaTransitionName;

        uiFade = GameObject.Find("UI_Canvas").GetComponent<UIFade>();
    }

    void Update()
    {
        if(shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime; // adjusts load time based on person's refresh time
            if(waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldLoadAfterFade = true;
            uiFade.FadeToBlack();
            PlayerController.instance.areaTransitionName = areaTransitionName;   // Do not ever need to reference the player
        }
    }
}
