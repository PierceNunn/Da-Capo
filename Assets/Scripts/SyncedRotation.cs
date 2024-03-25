/*****************************************************************************
// File Name : NoteChart.cs
// Author : Pierce Nunnelley
// Creation Date : March 12, 2024
//
// Brief Description : This script rotates an object in time with the
RhythmController.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncedRotation : MonoBehaviour
{
    //how frequently to update the rotation of the object
    [SerializeField] private float rotationInterval = 100f;
    
    /// <summary>
    /// Rotates the gameObject at a rate relative to the current RhythmController.
    /// </summary>
    void Update()
    {
        float rot = Mathf.Floor(RhythmController.instance.loopPositionInAnalog * rotationInterval) / rotationInterval;
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, 360,
            rot));
    }
}
