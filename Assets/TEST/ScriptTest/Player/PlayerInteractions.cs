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

    string tagName;
    public void Interact(InputAction.CallbackContext context)
    {
        if (canInteract && tagName == "CoreKey")
        {
            GetCoreKey();
        }

        if (canInteract && (tagName == "CoreEasy" || tagName == "CoreMedium" || tagName == "CoreHard"))
        {
            if(hasCoreKey == true)
            {
                UIManager.Instance.ActivetePuzzleCore(corePuzzleIndex);
            }
            else
            {
                UIManager.Instance.ShowNeedKeyMessage();
            }
        }

        if (canInteract && tagName == "Touchpad")
        {
            UIManager.Instance.ActivateTouchpadPanel();
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

            SoundManager.Instance.PlayGeneralSound(1, 0.75f);
            isCoreKey = false;
        }
    }

    private void OnTriggerEnter(Collider tri)
    {
        tagName = tri.tag;
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
        tagName = null;

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
