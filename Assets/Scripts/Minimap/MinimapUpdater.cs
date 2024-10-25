using UnityEngine;

namespace Minimap
{
    public class MinimapUpdater : MonoBehaviour
    {
        public Transform player;          // Referencia al jugador
        public Transform minimapCamera;   // Referencia a la cámara del minimapa
        public float updateInterval = 0.5f; // Tiempo entre actualizaciones en segundos (por ejemplo, 0.5 segundos)

        private float nextUpdateTime = 0f; // Almacena el tiempo del siguiente update

        void Update()
        {
            // Verifica si es hora de actualizar el minimapa
            if (Time.time >= nextUpdateTime)
            {
                // Actualiza el minimapa
                UpdateMinimap();

                // Establece el tiempo para la siguiente actualización
                nextUpdateTime = Time.time + updateInterval;
            }
        }

        void UpdateMinimap()
        {
            // Aquí actualizamos la posición de los íconos en el minimapa o cualquier otro cambio necesario
            Vector3 playerPosition = player.position;
            Vector3 iconPosition = new Vector3(playerPosition.x, minimapCamera.position.y - 10f, playerPosition.z);
            transform.position = iconPosition;

            // Opcional: si quieres actualizar la rotación del icono
            transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
        }
    }
}
