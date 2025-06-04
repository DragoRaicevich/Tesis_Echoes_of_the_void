using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private bool canInteract;
    [Header("CORE PUZZLE")]
    private GameObject coreKeyObj;
    [SerializeField] private bool hasCoreKey;
    [SerializeField] private bool isCoreKey;
    private int corePuzzleIndex = -1;


    public void Interact(InputAction.CallbackContext context)
    {
        GetCoreKey();
        if (hasCoreKey && canInteract && corePuzzleIndex >= 0)
        {
            Debug.Log("Interacting with core puzzle at index: " + corePuzzleIndex);
            UIManager.Instance.ActivetePuzzleCore(corePuzzleIndex);
        }
        else if(hasCoreKey == false && canInteract)
        {
            UIManager.Instance.ShowNeedKeyMessage();
        }
    }

    private void GetCoreKey()
    {
        if (isCoreKey == true && canInteract)
        {
            hasCoreKey = true;
            coreKeyObj.SetActive(false);
            canInteract = false;
            UIManager.Instance.HideInteractionKeyMessage();

            isCoreKey = false;
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
                Debug.Log("Otro tag: " + tagName);
                break;
        }

        if(tagName == "CoreKey")
        {
            isCoreKey = true;
            coreKeyObj = tri.gameObject;
        }

        UIManager.Instance.ShowInteractionKeyMessage();
    }
    private void OnTriggerExit(Collider tri)
    {
        canInteract = false;

        if (tri.tag == "CoreEasy" || tri.tag == "CoreMedium" || tri.tag == "CoreHard")
        {
            corePuzzleIndex = -1;
        }

        if (tri.tag == "CoreKey")
        {
            isCoreKey = false;
            coreKeyObj = null;
        }

        UIManager.Instance.HideInteractionKeyMessage();
    }

    
}
