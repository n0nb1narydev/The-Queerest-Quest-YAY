using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{

    private UIFade uiFade;

    public string transitionName;

    void Start()
    {
        uiFade = GameObject.Find("UI_Canvas").GetComponent<UIFade>();

        if (transitionName == PlayerController.instance.areaTransitionName)
        {
            PlayerController.instance.transform.position = transform.position;
        }

        uiFade.FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
