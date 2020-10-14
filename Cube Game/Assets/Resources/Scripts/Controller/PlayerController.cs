using System;
using Resources.Scripts.Model;
using UnityEngine;

namespace Resources.Scripts.Controller
{
    public class PlayerController : MonoBehaviour, Initializable
    {
        private float _moveSpeed = 5;
        private float _rotateSpeed = 2;

        public void Init(GameModel gameModel)
        {
            PlayerModel playerModel = (PlayerModel) gameModel;
            _moveSpeed = playerModel.MoveSpeed;
            _rotateSpeed = playerModel.RotateSpeed;
        }

        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 playerDirection = new Vector3(horizontal, 0, vertical);
            gameObject.transform.Translate(playerDirection.normalized * (Time.deltaTime * _moveSpeed));
            Rotate();
        }

        private void Rotate()
        {
            bool leftButtonClick = Input.GetMouseButton(0);
            Plane playerPlane = new Plane(Vector3.up, transform.position);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float dist = 0.0f;
            if (!leftButtonClick || !playerPlane.Raycast(ray, out dist)) {
                return;
            }
            Vector3 targetPoint = ray.GetPoint(dist);

            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotateSpeed * Time.deltaTime);
        }
    }
}