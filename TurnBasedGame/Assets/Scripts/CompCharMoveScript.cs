using UnityEngine;
using UnityEngine.AI;

public class CompCharMoveScript : MonoBehaviour
{
    public GameObject[] compChars;
    public GameObject[] playerChars;
    public GameObject currentcompChar;
    public NavMeshAgent currentAgent;
    public int actionRand;
    public int compCharTurns = 0;
    public bool takingAction;

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
        if (compCharTurns == compChars.Length)
        {
            EventManagerScript.current.onPlayerTurn();
        }

        if (currentcompChar.transform.position == currentAgent.destination && GameManagerScript.enemyturn == true)
        {
            takingAction = false;
            makeAttack();
            compCharTurns += 1;
        }
    }

    public void OnEnemyTurn()
    {
        compCharTurns = 0;
        for (int i = 0; i < compChars.Length; i++)
        {
            while (takingAction != true)
            {
                currentcompChar = compChars[i];
                currentAgent = currentcompChar.GetComponent<NavMeshAgent>();
                actionRand = Random.Range(0, 1); // 0 = melee attack
                if (actionRand == 0)
                {
                    meleeAction();
                }
            }
        }
    }

    public void meleeAction()
    {
        for (int i = 0; i < playerChars.Length; i++)
        {
            {
                if (Vector3.Distance(currentcompChar.transform.position, playerChars[i].transform.position) < closestPlayerCharDistance)
                {
                    closestPlayerChar = playerChars[i];
                    closestPlayerCharDistance = Vector3.Distance(currentcompChar.transform.position, playerChars[i].transform.position);
                }
            }
        }
        currentAgent.destination = closestPlayerChar.transform.position + new Vector3(5,5,0);
        takingAction = true;
    }

    public void makeAttack()
    {
        if (actionRand == 0)
        {

        }
    }
}
