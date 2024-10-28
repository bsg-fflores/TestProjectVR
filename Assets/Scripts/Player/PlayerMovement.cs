using System;
using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviourPun
    {
        private Rigidbody rb;
        private Vector3 movement;
        [SerializeField] private float _speed = 5f;
        public Transform cameraTransform; // Referencia a la cámara

        [SerializeField] private GameObject playerSign;
        
        private float inputHorizontal;
        private float inputVertical;
        
        private Vector3 forward;
        private Vector3 right;

        private void Awake()
        {
            // if (!photonView.IsMine)
            // {
            //     cameraTransform.gameObject.SetActive(false);
            // }

            if (UnityEngine.Camera.main != null) cameraTransform = UnityEngine.Camera.main.gameObject.transform;
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            
            // playerSign.SetActive(false);
            
            if (photonView.IsMine)
            {
                playerSign.SetActive(true);
                photonView.RPC("SyncPlayerSignState", RpcTarget.AllBuffered, playerSign.activeSelf);
            }
        }

        private void Update()
        {

            // Aplicar movimiento al Rigidbody
            if (photonView.IsMine)
            {
                inputHorizontal = Input.GetAxis("Horizontal");
                inputVertical = Input.GetAxis("Vertical");
            
                forward = cameraTransform.forward;
                right = cameraTransform.right;
            
                forward.y = 0f;
                right.y = 0f;

                forward.Normalize();
                right.Normalize();
                
                movement = (right * inputHorizontal + forward * inputVertical);
            }
        }

        private void FixedUpdate()
        {
            if (photonView.IsMine)
            {
                rb.MovePosition(rb.position + movement * (_speed * Time.deltaTime));
            }
        }
        
        [PunRPC]
        public void SyncPlayerSignState(bool isActive)
        {
            playerSign.SetActive(isActive);
        }
    }
}
