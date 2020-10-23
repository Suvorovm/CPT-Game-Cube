using UnityEngine;

namespace Resources.Scripts.Gamekit.Model
{
    public class GameModel : MonoBehaviour
    {
        [SerializeField]
        private GameObjectType _gameObjectType;
        public GameObjectType GameObjectType
        {
            get { return _gameObjectType; }
            protected set
            {
                _gameObjectType = value;
            }
        }
    }
}