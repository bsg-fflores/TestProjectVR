using System;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class PlayerMaterialManager : MonoBehaviourPunCallbacks, IPunObservable
    {
        private Renderer playerRenderer; // The Renderer to change the player's material
        public Material[] availableMaterials; // List of available materials (configured in the inspector)
        private int assignedMaterialIndex; // Index of the assigned material

        private void Awake()
        {
            playerRenderer = GetComponentInChildren<Renderer>();
        }

        private void Start()
        {

            if (playerRenderer == null)
            {
                Debug.LogError("Renderer component not found on the player object or its children.");
                return;
            }

            if (photonView.IsMine)
            {
                AssignMaterial();
            }
        }
        
        private void AssignMaterial()
        {
            assignedMaterialIndex = Random.Range(0, availableMaterials.Length);

            playerRenderer.material = availableMaterials[assignedMaterialIndex];
            // playerMarker.playerSign.GetComponent<Renderer>().material = availableMaterials[assignedMaterialIndex];

            photonView.RPC("SyncMaterialWithOthers", RpcTarget.AllBuffered, assignedMaterialIndex);
        }

        [PunRPC]
        private void SyncMaterialWithOthers(int materialIndex)
        {
            if (playerRenderer == null)
            {
                Debug.LogError("Renderer component not found on the player object or its children.");
                return;
            }

            assignedMaterialIndex = materialIndex;
            playerRenderer.material = availableMaterials[assignedMaterialIndex];
            // playerMarker.playerSign.GetComponent<Renderer>().material = availableMaterials[assignedMaterialIndex];
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(assignedMaterialIndex);
            }
            else
            {
                assignedMaterialIndex = (int)stream.ReceiveNext();
                if (playerRenderer != null)
                {
                    playerRenderer.material = availableMaterials[assignedMaterialIndex];
                }
            }
        }
    }
}