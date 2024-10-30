using System;
using Photon.Pun;
using UnityEngine;

namespace TestPhoton.RequestTakeOver
{
    public class ObtainableSphere : MonoBehaviourPun
    {
        private void OnMouseDown()
        {
            Debug.Log("OnMouseDown");
            photonView.RequestOwnership();
        }

        private void OnEnable()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }

        private void OnDisable()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }

        public void OnOwnershipRequest(PhotonView targetView, Photon.Realtime.Player requestingPlayer)
        {
            if (targetView != null && targetView == photonView)
            {
                if (photonView.Owner == null)
                {
                    photonView.TransferOwnership(requestingPlayer);
                }
            }
        }

        void Update()
        {
            Debug.Log("Owner: " + photonView.Owner);
            Debug.Log("IsMine: " + PhotonNetwork.LocalPlayer);
            if (photonView.IsMine)
            {
                float moveSpeed = 5f;
            
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");
            
                transform.position += transform.up * (vertical * moveSpeed * Time.deltaTime);
                transform.position += transform.right * (horizontal * moveSpeed * Time.deltaTime);
            }
        }
    }
}
