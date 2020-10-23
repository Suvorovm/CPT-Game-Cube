using Resources.Scripts.Gamekit.Model;
using UnityEngine;

namespace Resources.Scripts.Gamekit.Controller
{
    public class GateController : MonoBehaviour, Initializable
    {
        private static readonly int GATE_PARAMETER = Animator.StringToHash("gateParameter");
        private int _timeOut;
        private bool _activated;

        private float _lastAnimationTime;
        private Animator _animatorController;

        public void Init(GameModel gameModel)
        {
            GateModel gateModel = (GateModel) gameModel;
            _timeOut = gateModel.TimeOut;
            _animatorController = gameObject.GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            if (_timeOut > Time.realtimeSinceStartup - _lastAnimationTime || !_activated) {
                return;
            }
            
            _activated = false;
            _animatorController.SetBool(GATE_PARAMETER, false);
        }

        private void OnTriggerEnter(Collider other)
        {
            SphereModel sphereModel = other.GetComponent<SphereModel>();
            if (sphereModel == null) {
                return;
            }
            
            if (_timeOut > Time.realtimeSinceStartup - _lastAnimationTime && _activated) {
                return;
            }
            _activated = true;
            _lastAnimationTime = Time.realtimeSinceStartup;
            _animatorController.SetBool(GATE_PARAMETER, true);
        }
    }
}