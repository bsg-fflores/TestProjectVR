using System;
using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class PlayerGrabDirector : MonoBehaviourPun
    {
        private GameObject _grabberGameObject = null;
        
        private bool _isAnchored = false;
        private bool _isObjectNear = false;
       

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("GrabberObjects"))
            {
                Debug.Log("Object is near T");
                _isObjectNear = true;
                _grabberGameObject = other.gameObject;
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("GrabberObjects"))
            {
                Debug.Log("Object is near F");
                _isObjectNear = false;
            }
        }

        private void Update()
        {
            if (_isObjectNear && Input.GetKeyDown(KeyCode.E))
            {
                _isAnchored = !_isAnchored;
                photonView.RPC("AnchorPlayer", RpcTarget.AllBuffered, _isAnchored);
                Debug.Log("Object is anchored: " + _isAnchored);
            }

            if (_isAnchored)
            {
                _grabberGameObject.transform.position = transform.position;
            }
            
        }

        [PunRPC]
        private void AnchorPlayer(bool isAnchored)
        {
            _isAnchored = isAnchored;
        }
    }
}