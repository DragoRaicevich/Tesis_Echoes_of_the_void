using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzlePowerController : MonoBehaviour
{
    [SerializeField] private List<EnergyNode> energyNodeList;
    [SerializeField] private PowerSocket powerSocket;

    public List<EnergyNode> EnergyNodeList { get => energyNodeList; set => energyNodeList = value; }
    bool powerStationIsConnected = false;
    bool allNodesConected = true;


    public void CheckPower()
    {
        CheckNodes();

        if (allNodesConected == true && powerStationIsConnected == true)
        {
            Debug.Log("Puzzle is complete!");
            // Here you can add logic to handle the completion of the puzzle, like triggering an event or changing the game state.
        }
        else
        {
            Debug.Log("Puzzle is not complete yet.");
        }
    }

    private void CheckNodes()
    {
        foreach (var node in energyNodeList)
        {
            node.CheckConnectors();
            if (node.NodeHasPower == false)
            {
                allNodesConected = false;
                break;
            }
            else
            {
                allNodesConected = true;
            }
        }
        if (powerSocket.HasPower)
        {
            powerStationIsConnected = true;
        }
    }

}
