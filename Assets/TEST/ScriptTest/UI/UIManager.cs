using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI PLAYER")]
    [SerializeField] private GameObject HelmentImage;
    [Header("UI PUZZLE NODES")]
    [SerializeField] private GameObject puzzleNodesPanel;
    [SerializeField] private GameObject[] puzzleArrayPanels;

    [Header("PLAYER")]
    [SerializeField] private FirstPersonController firstPersonController;
    [SerializeField] private MouseLook mouseLook;


    public static UIManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void ActivetePuzzleCore(int index)
    {
        DeactivatePlayerControlls();
        puzzleArrayPanels[index].SetActive(true);
        puzzleNodesPanel.SetActive(true);
    }

    public void DeactivatePuzzleCore(int index)
    {
        puzzleNodesPanel.SetActive(false);
        puzzleArrayPanels[index].SetActive(false); // Desactiva el panel del puzzle según el índice
        ActivatePlayerControlls();

    }

    private void DeactivatePlayerControlls()
    {
        firstPersonController.enabled = false;
        mouseLook.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    private void ActivatePlayerControlls()
    {
        firstPersonController.enabled = true;
        mouseLook.enabled = true;
        Cursor.lockState = CursorLockMode.Locked; 
    }
}
