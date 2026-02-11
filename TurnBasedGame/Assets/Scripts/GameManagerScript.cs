using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public static bool playerTurn;
    public static bool enemyturn;
    void Start()
    {
        EventManagerScript.current.PlayerTurn += OnPlayerTurn;
        EventManagerScript.current.EnemyTurn += OnEnemyTurn;
        playerTurn = true;
        enemyturn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playerEndTurn()
    {
        EventManagerScript.current.onEnemyTurn();
    }

    public void OnPlayerTurn()
    {
        playerTurn = true;
        enemyturn = false;
    }
    public void OnEnemyTurn()
    {
        playerTurn = false;
        enemyturn = true;
    }
}
