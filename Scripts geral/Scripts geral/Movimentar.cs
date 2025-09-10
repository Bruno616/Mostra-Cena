using UnityEngine;

public class Movimentar: MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 100f;
    public Transform cameraTransform; // a câmera do player

    float xRotation = 0f;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // trava o mouse
    }

    void Update()
    {
        // Rotação do mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // só a câmera rotaciona vertical
        transform.Rotate(Vector3.up * mouseX); // rotaciona player horizontalmente

        // Movimento teclado
        float x = Input.GetAxis("Horizontal"); // A/D
        float z = Input.GetAxis("Vertical");   // W/S

        // Movimento relativo apenas à rotação horizontal do player
        Vector3 forward = transform.forward;
        forward.y = 0f; // ignora inclinação vertical
        forward.Normalize();

        Vector3 right = transform.right;
        right.y = 0f;
        right.Normalize();

        Vector3 move = right * x + forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
}
