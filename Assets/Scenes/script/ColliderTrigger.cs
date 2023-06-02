
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{

    public event EventHandler OnPlayerEnterTrigger;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        playerHealth player = collider.GetComponent<playerHealth>();
        if (player != null)
        {
            // Player inside trigger area!
            OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
        }
    }

}
