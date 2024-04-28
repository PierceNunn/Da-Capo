using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAnimator : MonoBehaviour
{
    public void ToggleAnAnimator(Animator animatorToToggle, bool statusToSet)
    {
        animatorToToggle.SetBool("Open", statusToSet);
    }
    public void OpenAnimator(Animator animatorToToggle)
    {
        ToggleAnAnimator(animatorToToggle, true);
    }
    public void CloseAnimator(Animator animatorToToggle)
    {
        ToggleAnAnimator(animatorToToggle, false);
    }
}
