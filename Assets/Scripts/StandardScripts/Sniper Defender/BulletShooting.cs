using System.Collections;
using UnityEngine;

namespace Sniper_Defender{
    [RequireComponent(typeof(SniperDefenderKeyListener))]
    public class BulletShooting : MonoBehaviour{
        [SerializeField] private GameObject BulletPrefab; 
        [SerializeField] private float _shotCooldown;

        private SniperDefenderKeyListener _keyListener;
        private Vector3 _currentMousePosition;
        private bool _canShot = true;

        private void Awake() {
            _keyListener = GetComponent<SniperDefenderKeyListener>();
        }

        private void OnEnable() {
            _keyListener.OnPressKeyEvent += GetMousePosition;
            _keyListener.OnPressKeyEvent += ShotWhenCoolDownIsOver;
        }

        private void OnDisable() {
            _keyListener.OnPressKeyEvent -= GetMousePosition;
            _keyListener.OnPressKeyEvent -= ShotWhenCoolDownIsOver;
        }


        private Vector3 GetBulletDirection() {
            var direction = (_currentMousePosition - transform.position).normalized;
            return direction;
        }
        
        public void ShotWhenCoolDownIsOver(Vector3 aux) {
            if (_canShot) {
                InstantiateBullet();
                StartCoroutine(ManageShotCooldown());
            }
        }

        private IEnumerator ManageShotCooldown() {
            _canShot = false;
            yield return new WaitForSeconds(_shotCooldown);
            _canShot = true;
        }
        
        public void InstantiateBullet() {
            var direction = GetBulletDirection();

            var rotation = Mathf.Atan2(direction.y, direction.x)  * Mathf.Rad2Deg;

            var gameobj = Instantiate(BulletPrefab, transform.position, Quaternion.Euler(rotation * Vector3.forward));

            
            
            gameobj.GetComponent<Bullet>().SetSpeedVector(new Vector3(direction.x, direction.y, 0f).normalized);
            
            // _currentTargetTransform = _currentTargetChanged.GetCurrentTarget().GetComponent<Transform>();
            // var vectorDirection = (_currentTargetTransform.position - transform.position).normalized;
            // var rotation = Mathf.Atan2(vectorDirection.y, vectorDirection.x) * Mathf.Rad2Deg - 90f;
            // transform.eulerAngles = Vector3.forward * rotation;
        }
        
        private void GetMousePosition(Vector3 newMousePosition) {
            _currentMousePosition = newMousePosition;
        }
        
    }
}