using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("CORE ZONE")]
    [SerializeField] private bool coreZoneCompleted = false;
    private int coresComplete = 0;
    [Header("WIRING ZONE")]
    [SerializeField] private bool wiringZoneCompleted = false;
    private void Start()
    {
        PuzzlePowerController.OnCoreCompleted += CoreComplete;
    }

    private void OnDisable()
    {
        PuzzlePowerController.OnCoreCompleted -= CoreComplete;
    }

    private void CoreComplete()
    {
        coresComplete++;
        if (coresComplete >= 3)
        {
            Debug.Log("All cores completed!");
            coreZoneCompleted = true;
        }
    }
}
