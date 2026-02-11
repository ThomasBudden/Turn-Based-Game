using UnityEngine;
using UnityEngine.AI;

public class CompCharMoveScript : MonoBehaviour
{
    public GameObject[] compChars;
    public GameObject[] playerChars;
    public GameObject currentcompChar;
    public NavMeshAgent currentAgent;
    public int actionRand;

    public GameObject closestPlayerChar;
    public float closestPlayerCharDistance = 100000;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventManagerScript.current.EnemyTurn += OnEnemyTurn;
        playerChars = this.GetComponent<PlayerControlScript>().playerCharArray;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnEnemyTurn()
    {
        for (int i = 0; i < compChars.Length; i++)
        {
            currentcompChar = compChars[i];
            currentAgent = currentcompChar.GetComponent<NavMeshAgent>();
            actionRand = Random.Range(0, 1);
            if (actionRand == 0)
            {
                meleeAction();
            }
        }
        EventManagerScript.current.onPlayerTurn();
    }

    public void meleeAction()
    {
        for (int i = 0; i < playerChars.Length; i++)
        {
            {
                if (Vector3.Distance(currentcompChar.transform.position, playerChars[i].transform.position) < closestPlayerCharDistance)
                {
                    closestPlayerChar = playerChars[i];
                }
            }
        }
        currentAgent.destination = closestPlayerChar.transform.position + new Vector3(5,5,0);
    }
}
