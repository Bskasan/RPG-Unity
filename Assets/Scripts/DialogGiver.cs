using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogGiver : MonoBehaviour
{
    [SerializeField] private TextAsset _dialog;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ThirdPersonMover>() != null) 
        {
            FindObjectOfType<DialogController>().StartDialog(_dialog);
        }
    }
}
