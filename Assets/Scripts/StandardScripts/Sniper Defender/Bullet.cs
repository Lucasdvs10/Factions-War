using System;
using UnityEngine;

namespace Sniper_Defender{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour{
        [SerializeField] private float _speed;
        [SerializeField] private float _bulletLifeTime;
        [SerializeField] private float _damageToApply;
        private Rigidbody2D _rgb;

        private void Awake() {
            _rgb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable() {
            Destroy(transform.gameObject, _bulletLifeTime);
        }


        private void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.tag == "Defenders") return;

            var otherLifeScript = other.gameObject.GetComponent<LifeScript>();

            otherLifeScript?.ApplyDamage(_damageToApply);
            Destroy(transform.gameObject);
        }
        public void SetSpeedVector(Vector3 direction) {
            _rgb.velocity = direction * _speed;
        }
        
        
        
    }
}