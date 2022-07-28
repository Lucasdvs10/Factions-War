using UnityEngine;

namespace Sniper_Defender{
    public class RotateSniperWhenShoot : MonoBehaviour{
        private SniperDefenderKeyListener _keyListener;
        private Vector3 _currentMousePosition;

        private void Awake() {
            _keyListener = GetComponentInChildren<SniperDefenderKeyListener>();
        }

        private void OnEnable() {
            _keyListener.OnPressKeyEvent += GetMousePosition;
            _keyListener.OnPressKeyEvent += Rotate;
        }
        
        private void OnDisable() {
            _keyListener.OnPressKeyEvent -= GetMousePosition;
            _keyListener.OnPressKeyEvent -= Rotate;
        }

        private void GetMousePosition(Vector3 position) {
            _currentMousePosition = position;
        }
        
        private void Rotate(Vector3 aux) {
            var direction = (_currentMousePosition - transform.position).normalized;
            
            var rotation = Mathf.Atan2(-direction.x, direction.y)  * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(Vector3.forward * rotation);
        }
        
    }
}