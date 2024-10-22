using System;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestPhoton
{
    public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField createRoomNameInputField;
        [SerializeField] private TMP_InputField joinRoomNameInputField;

        private void Start()
        {
            
        }

        public void CreateRoom()
        {
            PhotonNetwork.CreateRoom(createRoomNameInputField.text, new RoomOptions{MaxPlayers = 4, IsVisible = true, IsOpen = true}, TypedLobby.Default, null);
        }

        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(joinRoomNameInputField.text);
        }

        public override void OnJoinedRoom()
        {
            
            PhotonNetwork.LoadLevel("SampleScene");
        }
    }
}
