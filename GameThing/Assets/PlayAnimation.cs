using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public Animator glassAnimation;

    public void PlayGlassOpenAnimation()
    {
        glassAnimation.GetBool("Open");
    }

    public void PlayGlassCloseAnimation()
    {
        glassAnimation.GetBool("Close");
    }


}
