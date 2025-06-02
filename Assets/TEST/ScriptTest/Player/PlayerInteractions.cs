using System;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private bool canInteract;



    private void OnTriggerEnter(Collider tri)
    {
        if (tri.tag == "NodesPuzzle1")
        {
            canInteract = true;
        }
    }
    private void OnTriggerExit(Collider tri)
    {
        if (tri.tag == "NodesPuzzle1")
        {
            canInteract = false;
        }
    }
}
