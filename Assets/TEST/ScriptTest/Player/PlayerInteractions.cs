using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    [Header("CORE PUZZLES")]
    [SerializeField] private bool canInteract;
    [SerializeField] private int corePuzzleIndex = -1;

 
    public void Interact(InputAction.CallbackContext context)
    {
        if (canInteract && corePuzzleIndex >= 0)
        {
            UIManager.Instance.ActivetePuzzleCore(corePuzzleIndex);
        }
    }


    private void OnTriggerEnter(Collider tri)
    {
        string tagName = tri.tag;
        canInteract = true;
        switch (tagName)
        {
            case "CoreEasy":
                corePuzzleIndex = 0;
                break;
            case "CoreMedium":
                corePuzzleIndex = 1;
                break;
            case "CoreHard":
                corePuzzleIndex = 2;
                break;
            default:
                Debug.Log("Tag desconocido: " + tagName);
                break;
        }

    }
    private void OnTriggerExit(Collider tri)
    {
        if (tri.tag == "CoreEasy" || tri.tag == "CoreMedium" || tri.tag == "CoreHard")
        {
            canInteract = false;
            corePuzzleIndex = -1;
        }
    }
}
