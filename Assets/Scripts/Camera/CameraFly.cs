using UnityEngine;

namespace Camera
{
    public class CameraFly : MonoBehaviour
    {
        public float movementSpeed = 10f;
        public float lookSpeed = 2f;

        private void Update()
        {
            // Movimiento de la cámara con el teclado
            float moveForward = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
            float moveRight = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
            float moveUp = 0;

            if (Input.GetKey(KeyCode.E))
            {
                moveUp = movementSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                moveUp = -movementSpeed * Time.deltaTime;
            }

            transform.Translate(moveRight, moveUp, moveForward);

            // Rotación de la cámara con el mouse
            float yaw = lookSpeed * Input.GetAxis("Mouse X");
            float pitch = -lookSpeed * Input.GetAxis("Mouse Y");

            transform.eulerAngles += new Vector3(pitch, yaw, 0);
        }
    }
}
