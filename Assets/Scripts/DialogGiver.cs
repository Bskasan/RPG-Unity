using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogGiver : MonoBehaviour
{
    [SerializeField] private TextAsset _dialog;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<ThirdPersonMover>();
        if ( player != null) 
        {
            FindObjectOfType<DialogController>().StartDialog(_dialog);
        }
    }
}
