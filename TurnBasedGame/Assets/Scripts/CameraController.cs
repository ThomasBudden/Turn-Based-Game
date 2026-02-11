using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cam;
    public GameObject camCenter;
    public GameObject mainCamCenter;
    public float speed;
    public float mouseSensitivity;
    public float cameraHorizontalRotation = 0f;
    public float cameraVerticalRotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            mainCamCenter.transform.RotateAround(camCenter.transform.position, Vector3.up, -speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            mainCamCenter.transform.RotateAround(camCenter.transform.position, Vector3.up, speed * Time.deltaTime);
        }

        if (Input.GetMouseButton(2))
        {
            float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;

            float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            cameraVerticalRotation -= inputY;
            cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
            cam.transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

            mainCamCenter.transform.Rotate(Vector3.up * inputX);
        }
    }
}
