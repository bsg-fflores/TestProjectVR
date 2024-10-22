using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviourPunCallbacks
    {
        public GameObject playerPrefab;
        [SerializeField] Transform playerSpawnPoint;
        
        void Start()
        {
            SpawmPlayer();
        }
        
        [PunRPC]
        private void SpawmPlayer()
        {
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector3( 3, 1, Random.Range(3, 8)), Quaternion.identity);
        }
        
        
        public override void OnJoinedRoom()
        {
            Debug.Log("Jugador ha ingresado a la sala.");

            if (PhotonNetwork.IsConnectedAndReady)
            {
                photonView.RPC("SpawnPlayer", RpcTarget.AllBuffered);
            }
        }
    }
}
