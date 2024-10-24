using System;
using Photon.Pun;
using UnityEngine;

namespace Bot
{
    public class AnchorObjectToPlayer : MonoBehaviourPun
    {
        private bool _playerIsNear = false;
        private bool _isAnchored = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _playerIsNear = true;
                // Debug.Log("Player is near");
            }
        }
        
        private void Update()
        {
            if (_playerIsNear && Input.GetKeyDown(KeyCode.E) && photonView.IsMine)
            {
                _isAnchored = !_isAnchored;
                photonView.RPC("AnchorPlayer", RpcTarget.AllBuffered, _isAnchored);
                Debug.Log("Player is anchored: " + _isAnchored);
            }
            
            if (_isAnchored)
            {
                transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
            }
        }
        
        [PunRPC]
        private void AnchorPlayer(bool isAnchored)
        {
            _isAnchored = isAnchored;
        }
    }
}
