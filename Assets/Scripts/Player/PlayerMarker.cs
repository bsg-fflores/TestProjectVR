using System;
using Photon.Pun;
using UnityEngine;

namespace Player
{
    // public class PlayerMarker : MonoBehaviourPun, IPunObservable
    public class PlayerMarker : MonoBehaviourPun, IPunObservable
    {
        public GameObject playerSign;

        private void Awake()
        {
            playerSign = transform.GetChild(0).gameObject;
        }
        
        private void Start()
        {
            if (photonView.IsMine)
            {
                playerSign.SetActive(true);
            }
        }
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(playerSign.activeSelf);
            }
            else
            {
                bool isActive = (bool)stream.ReceiveNext();
                playerSign.SetActive(isActive);
            }
        }
    }
}