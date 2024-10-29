using System;
using Photon.Pun;
using UnityEngine;

namespace Bot
{
    public class InstanciadorObjetos : MonoBehaviourPun
    {
        private void Start()
        {
            PhotonNetwork.InstantiateRoomObject("Prefabs/Cube", new Vector3(5, 0.5f, 12), Quaternion.identity);
        }
    }
}