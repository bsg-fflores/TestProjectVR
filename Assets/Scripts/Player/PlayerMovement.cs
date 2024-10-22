using System;
using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviourPun
    {
        private Rigidbody rb;
        private Vector3 movement;
        [SerializeField] private float _speed;
        public Transform cameraTransform; // Referencia a la cámara

        [SerializeField] private GameObject playerSign;

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
            
            playerSign.SetActive(false);
            
            if (photonView.IsMine)
            {
                playerSign.SetActive(true);
            }
        }

        private void Update()
        {

            // Aplicar movimiento al Rigidbody
            
            
        }

        private void FixedUpdate()
        {
            if (photonView.IsMine)
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");
            
                Vector3 forward = cameraTransform.forward;
                Vector3 right = cameraTransform.right;
            
                forward.y = 0f;
                right.y = 0f;

                forward.Normalize();
                right.Normalize();
            
            
                movement = (right * horizontal + forward * vertical) * (_speed * Time.deltaTime);
                rb.MovePosition(rb.position + movement * (_speed * Time.deltaTime));
            }
        }
    }
}
