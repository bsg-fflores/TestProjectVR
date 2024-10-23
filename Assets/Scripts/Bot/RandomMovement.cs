using UnityEngine;
using Photon.Pun;

namespace Bot
{
    public class RandomMovement : MonoBehaviourPunCallbacks
    {
        public float moveSpeed = 2.0f; // Velocidad del movimiento
        public float moveInterval = 2.0f; // Intervalo entre movimientos
        private Vector3[] directions; // Direcciones posibles de movimiento
        
        public Vector3 currentDirection; // Dirección actual del movimiento

        private void Start()
        {
            directions = new [] {
                Vector3.up, Vector3.down, Vector3.left, Vector3.right
            }; // Direcciones posibles de movimiento
            Debug.Log("Start");
            // Solo el propietario del PhotonView debe controlar el movimiento aleatorio
            InvokeRepeating("MoveRandomly", moveInterval, moveInterval);
        }

        // Método que mueve el objeto en una dirección aleatoria
        private void MoveRandomly()
        {
            // Elegimos una dirección aleatoria de las 4 direcciones posibles
            int randomIndex = Random.Range(0, directions.Length);
            Vector3 randomDirection = directions[randomIndex];
            currentDirection = randomDirection;

            // Movemos el objeto en la dirección seleccionada
            transform.Translate(randomDirection * (moveSpeed * Time.deltaTime));

            // La posición se sincronizará automáticamente con todos los jugadores gracias a PhotonTransformView
        }
    }
}
