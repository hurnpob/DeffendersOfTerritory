using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    int selected;
    [SerializeField] GameManager gm;
    [SerializeField] Tower towerPrefab2;
    
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    GridManager gridManager;
    Pathfinder pathfinder;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
        
    }

    void Start()
    {
        
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if(!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }


    void OnMouseDown()
    {
        SelectedCheck();
        if(gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            if (selected == 1)
            {
                bool isSuccessful = towerPrefab.CreateTower(towerPrefab, transform.position);
                Debug.Log(selected);
                if(isSuccessful)
            {
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyReceivers();
            }
            }

            if (selected == 2)
            {
                bool isSuccessful = towerPrefab2.CreateTower(towerPrefab2, transform.position);
                Debug.Log(selected);
                if(isSuccessful)
            {
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyReceivers();
            }
            }
            
        }
    }

    public void SelectedCheck()
    {
        selected = gm.TowerProperty;
        print(selected);
    }
}
