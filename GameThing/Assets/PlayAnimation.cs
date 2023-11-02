using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public Animator glassAnimation;
    private bool open;

    public void Start()
    {
        glassAnimation.SetBool("Open", false);
        glassAnimation.SetBool("Close", false);
        open = false;
    }

    public void OpenANim()
    {
        open = true;
        glassAnimation.SetBool("Open", true);
        glassAnimation.SetBool("Close", false);

    }

    public void CloseANim()
    {
        glassAnimation.SetBool("Open", false);
        glassAnimation.SetBool("Close", true);
        open = false;
    }


}
