using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControlScript : MonoBehaviour
{
    public GameObject Chars;
    public bool playerTurn;
    public GameObject[] playerCharArray;
    public GameObject currentChar;
    public bool characterSelected;
    private Vector3 hitPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit raycastHit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out raycastHit, 100f))
                {
                    if (raycastHit.transform != null)
                    {
                       PickingChar(raycastHit.transform.gameObject);
                    }
                }
            }
            if (Input.GetMouseButtonDown(0) && characterSelected == true)
            {
                RaycastHit raycastHit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out raycastHit, 100f))
                {
                    Vector3 hitPoint = raycastHit.point;
                    if (raycastHit.transform != null)
                    {
                        MovingChar(raycastHit.transform.gameObject);
                    }
                }
            }
        }
    }
    public void PickingChar(GameObject gameObject)
    {
        if (gameObject.tag == "PlayerChar")
        {
            currentChar = gameObject;
            characterSelected = true;
        }
    }
    public void MovingChar(GameObject gameObject)
    {
        if (gameObject.tag == "Ground")
        {
            currentChar.GetComponent<NavMeshAgent>().destination = hitPoint;
        }
    }
}
