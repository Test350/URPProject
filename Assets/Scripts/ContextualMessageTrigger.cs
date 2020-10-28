using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextualMessageTrigger : MonoBehaviour
{
    [SerializeField]
    [TextArea(3,5)]
    string message = "Default";
    [SerializeField]
    float messageDuration = 1.0f;

    public static event Action<string, float> ContextualMessageTriggered;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            if (ContextualMessageTriggered != null)
            {
                ContextualMessageTriggered.Invoke(message, messageDuration);               
            }


        }
    }
}
