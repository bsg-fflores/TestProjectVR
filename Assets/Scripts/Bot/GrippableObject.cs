using System;
using Photon.Pun;
using UnityEngine;

namespace Bot
{
    public class GrippableObject : MonoBehaviourPun
    {
        private void Start()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                int ownerId = PhotonNetwork.LocalPlayer.ActorNumber;
                photonView.ViewID = PhotonNetwork.AllocateViewID(ownerId);
                photonView.RPC("SyncViewID", RpcTarget.AllBuffered, photonView.ViewID);
            }
        }
        
        [PunRPC]
        private void SyncViewID(int viewID)
        {
            photonView.ViewID = viewID;
        }
    }
}
