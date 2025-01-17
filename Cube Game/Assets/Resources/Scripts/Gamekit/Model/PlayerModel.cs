﻿using UnityEngine;

namespace Resources.Scripts.Gamekit.Model
{
    public class PlayerModel : GameModel
    {
       
        [SerializeField]
        private float _moveSpeed;
        [SerializeField]
        private float _rotateSpeed;
        
        public float RotateSpeed
        {
            get { return _rotateSpeed; }
        }

        public float MoveSpeed
        {
            get { return _moveSpeed; }
        }
    }
}
