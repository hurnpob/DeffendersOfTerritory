using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int towerSelector;
        public int TowerProperty
    {
        get { return towerSelector; }
    }

    [SerializeField] GameObject tower1;
    [SerializeField] GameObject tower2;

    public void Tower1()
    {
        if (towerSelector != 1)
        {
            towerSelector = 1;
        }
    }

    public void Tower2()
    {
        if (towerSelector != 2)
        {
            towerSelector = 2;
        }
    }



}
