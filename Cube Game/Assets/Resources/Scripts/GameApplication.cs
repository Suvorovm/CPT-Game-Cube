using Resources.Scripts.Service;
using UnityEngine;

namespace Resources.Scripts
{
    public class GameApplication : MonoBehaviour
    {
        private GameObject _container;
        private void Start()
        {
            _container = new GameObject("container");
            _container.transform.SetParent(gameObject.transform, true);
            GameWorldService gameWorldService = _container.AddComponent<GameWorldService>();
            gameWorldService.Configure();
        }
    }
}
