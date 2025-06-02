using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionNode : MonoBehaviour, IPointerDownHandler
{
    private float currentRotation;
    [SerializeField] private EnergyNode energyNode;
    [SerializeField] private bool isSeleccted = false;
    [SerializeField] private PuzzlePowerController powerController;

    private void Start()
    {
        currentRotation = transform.rotation.eulerAngles.z;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        currentRotation += 90f;
        transform.rotation = Quaternion.Euler(0, 0, currentRotation);
    }
}
