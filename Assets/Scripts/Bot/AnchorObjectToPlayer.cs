using System;
using UnityEngine;

namespace Bot
{
    public class AnchorObjectToPlayer : MonoBehaviour
    {
        public Transform player;
        public Vector3 offset;

        private void Awake()
        {
        }

        private void Start()
        {
            player = GameObject.FindWithTag("Player").transform;
            offset = new Vector3(0, 0.5f, 2);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                transform.SetParent(player);
                transform.localPosition = offset;
            }
        }
    }
}
