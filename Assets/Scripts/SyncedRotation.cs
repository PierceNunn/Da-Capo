using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncedRotation : MonoBehaviour
{
    [SerializeField] private float rotationInterval = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rot = Mathf.Floor(RhythmController.instance.loopPositionInAnalog * rotationInterval) / rotationInterval;
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, 360,
            rot));
    }
}
