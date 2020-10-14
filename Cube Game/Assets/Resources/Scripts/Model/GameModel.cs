using UnityEngine;

namespace Resources.Scripts.Model
{
    public class GameModel : MonoBehaviour
    {
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