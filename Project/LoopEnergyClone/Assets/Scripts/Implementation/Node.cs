using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public bool isConnected = false; // Track if the node is connected
    public Node[] neighbors; // Array to hold references to neighboring nodes (up, right, down, left)
    public bool[] connectionDirections; // Boolean array indicating possible connections (up, right, down, left)

    // Visited nodes during a connection check
    private HashSet<Node> visitedNodes;

    private void OnMouseDown()
    {
        RotateNode();
        visitedNodes = new HashSet<Node>(); // Initialize visited nodes set
        CheckConnections();
    }

    private void RotateNode()
    {
        transform.Rotate(0, 0, -90);
        RotateConnectionDirections();
    }

    private void RotateConnectionDirections()
    {
        bool lastElement = connectionDirections[connectionDirections.Length - 1];
        for (int i = connectionDirections.Length - 1; i > 0; i--)
        {
            connectionDirections[i] = connectionDirections[i - 1];
        }
        connectionDirections[0] = lastElement;
    }

    public void CheckConnections()
    {
        visitedNodes.Add(this);
        isConnected = true;

        for (int i = 0; i < neighbors.Length; i++)
        {
            if (neighbors[i] != null)
            {
                // Check if the current node's connection direction aligns with the neighbor's opposite direction
                int oppositeDirection = (i + 2) % 4; // 0 -> 2 (up <-> down), 1 -> 3 (right <-> left)
                if (connectionDirections[i] && neighbors[i].connectionDirections[oppositeDirection])
                {
                    if (!visitedNodes.Contains(neighbors[i]))
                    {
                        neighbors[i].visitedNodes = visitedNodes; // Pass visited nodes to neighbors
                        neighbors[i].CheckConnections(); // Recursively check neighboring nodes
                        Debug.Log($"Node {name} checking connection to {neighbors[i].name} on direction {i}");

                    }
                }
                else
                {
                    if (!connectionDirections[i] && !neighbors[i].connectionDirections[oppositeDirection])
                    {

                    }
                    else
                    {
                        isConnected = false;
                        Debug.Log($"Node {name} disconected from {neighbors[i].name} on direction {i} {connectionDirections[i]} and {oppositeDirection} {neighbors[i].connectionDirections[oppositeDirection]}");

                    }

                }
            }
            else if (connectionDirections[i]) // If there's no neighbor where there should be a connection
            {
                isConnected = false;
            }
        }

        // If the node is not connected, disconnect any nodes that depend on it
        if (!isConnected)
        {
            foreach (var neighbor in neighbors)
            {
                if (neighbor != null && neighbor.isConnected)
                {
                    neighbor.isConnected = false;
                }
            }
        }
    }
}
