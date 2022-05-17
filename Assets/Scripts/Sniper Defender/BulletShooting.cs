using Unity.Mathematics;
using UnityEngine;

namespace Sniper_Defender{
    [RequireComponent(typeof(SniperDefenderKeyListener))]
    public class BulletShooting : MonoBehaviour{
        private SniperDefenderKeyListener _keyListener;
        private Vector3 _currentMousePosition;
        [SerializeField] private GameObject BulletPrefab;
        

        private void Awake() {
            _keyListener = GetComponent<SniperDefenderKeyListener>();
        }

        private void OnEnable() {
            _keyListener.OnPressKeyEvent += GetMousePosition;
            _keyListener.OnPressKeyEvent += InstantiateBullet;
        }

        private void OnDisable() {
            _keyListener.OnPressKeyEvent -= GetMousePosition;
            _keyListener.OnPressKeyEvent -= InstantiateBullet;
        }


        private Vector3 GetBulletDirection() {
            var direction = (_currentMousePosition - transform.position);
            direction = new Vector3(direction.x, direction.y, 0).normalized;
            return direction;
        }
        
        //todo: Rotacionar a bala em si
        //todo: Alinhar o target com a bala, por exemplo, se atirar para trás, o target deve ir para trás tbm
        //todo: Quanto mais longe o mouse, mais rápido fica, e quanto mais perto, mais lento, e se próximo, a bala muda de direção e fica lentíssima
        public void InstantiateBullet(Vector3 asd) {
            var direction = GetBulletDirection();

            var rotation = Vector3.Angle(direction, Vector3.right);            
            
            var gameobj = Instantiate(BulletPrefab, transform.position, quaternion.Euler(Vector3.forward*rotation));
            
            gameobj.GetComponent<Bullet>().SetSpeedVector(direction);
        }
        
        private void GetMousePosition(Vector3 newMousePosition) {
            _currentMousePosition = newMousePosition;
        }
        
    }
}