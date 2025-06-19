using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 100f;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limita a rotação vertical

        // Rotaciona a câmera (olhar pra cima/baixo)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotaciona o corpo do player (olhar pros lados)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
