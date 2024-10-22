using System;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

namespace TestPhoton
{
    public class ConnectToServer : MonoBehaviourPunCallbacks
    {
        private void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
            // PhotonNetwork.AutomaticallySyncScene = true;
        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedLobby()
        {
            Debug.Log("Connected");
            SceneManager.LoadScene(1);
        }
    }
}
