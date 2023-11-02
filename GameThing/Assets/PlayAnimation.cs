using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public Animator glassAnimation;

    public void PlayGlassOpenAnimation()
    {
        glassAnimation.SetTrigger("Open");
    }

    public void PlayGlassCloseAnimation()
    {
        glassAnimation.SetTrigger("Close");
    }
}
