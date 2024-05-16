using System;
using UnityEngine;
namespace OtusProject.Player.Hit
{
    public sealed class HitEvents : MonoBehaviour
    {
        public event Action OnCollision;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                OnCollision?.Invoke();
            }
        }
    }
}