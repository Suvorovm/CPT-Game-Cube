using UnityEngine;

namespace Resources.Scripts.Gamekit.Model
{
    public class GateModel : GameModel
    {
        [SerializeField]
        private int _timeOut;

        public void Awake()
        {
            GameObjectType = GameObjectType.GATES;
        }

        public int TimeOut
        {
            get { return _timeOut; }
        }
    }
}