using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EventManagerScript : MonoBehaviour
{
    public static EventManagerScript current;

    private void Awake()
    {
        current = this;
    }

    public event Action PlayerTurn;
    public void onPlayerTurn()
    {
        if (PlayerTurn != null)
        {
            PlayerTurn();
        }
    }

    public event Action EnemyTurn;
    public void onEnemyTurn()
    {
        if (EnemyTurn != null)
        {
            EnemyTurn();
        }
    }
}
