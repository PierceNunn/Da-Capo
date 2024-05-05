/*****************************************************************************
// File Name : ToggleAnimator.cs
// Author : Pierce Nunnelley
// Creation Date : May 1, 2024
//
// Brief Description : This simple script allows for easy toggling between
// two animations on an animator from unityEvent calls, used for things such
// as buttons.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAnimator : MonoBehaviour
{
    /// <summary>
    /// Simple function to set a bool in an animator to a given state.
    /// </summary>
    /// <param name="animatorToToggle">the animator to run the command on.</param>
    /// <param name="statusToSet">the state to set the bool as.</param>
    /// <param name="boolName">the name of the bool to set.</param>
    public void ToggleAnAnimator(Animator animatorToToggle, bool statusToSet, string boolName)
    {
        animatorToToggle.SetBool(boolName, statusToSet);
    }

    /// <summary>
    /// Sets an animator's bool named Open to true.
    /// </summary>
    /// <param name="animatorToToggle">Animator to run on.</param>
    public void OpenAnimator(Animator animatorToToggle)
    {
        ToggleAnAnimator(animatorToToggle, true, "Open");
    }

    /// <summary>
    /// Sets an animator's bool named Open to false.
    /// </summary>
    /// <param name="animatorToToggle">Animator to run on.</param>
    public void CloseAnimator(Animator animatorToToggle)
    {
        ToggleAnAnimator(animatorToToggle, false, "Open");
    }
}
