using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject otherpanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventManagerScript.current.PlayerTurn += OnPlayerTurn;
        EventManagerScript.current.EnemyTurn += OnEnemyTurn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerTurn()
    {
        otherpanel.SetActive(true);
    }
    public void OnEnemyTurn()
    {
        otherpanel.SetActive(false);
    }

    public void OnEndTurnPress()
    {
        EventManagerScript.current.onEnemyTurn();
    }
}
