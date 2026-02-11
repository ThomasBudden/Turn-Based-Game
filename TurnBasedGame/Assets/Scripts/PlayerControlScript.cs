using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControlScript : MonoBehaviour
{
    public GameObject Chars;
    public GameObject camCenter;
    public GameObject[] playerCharArray;
    public GameObject currentChar;
    public bool characterSelected;
    private Vector3 hitPoint;
    public bool[] currentAction; //0 = move
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (characterSelected == true)
        {
            camCenter.transform.position = currentChar.transform.position;
        }
        if (Input.GetMouseButtonDown(1) && characterSelected == true && currentAction[0] == true && GameManagerScript.playerTurn == true)
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                Vector3 hitPoint = raycastHit.point;
                currentChar.GetComponent<NavMeshAgent>().destination = hitPoint;
            }
        }
    }
    public void PickingChar1()
    {
        currentChar = playerCharArray[0];
        characterSelected = true;
    }
    public void PickingChar2()
    {
        currentChar = playerCharArray[1];
    }
    public void PickingChar3()
    {
        currentChar = playerCharArray[2];
    }
    public void PickingChar4()
    {
        currentChar = playerCharArray[3];
    }

    public void moveSelected()
    {
        for (int i = 0; i < currentAction.Length; i++)
        {
            if (i == 0)
            {
                currentAction[i] = true;
            }
            else if (i != 0)
            {
                currentAction[i] = false;
            }
        }
    }
}
