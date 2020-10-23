using JetBrains.Annotations;
using Resources.Scripts.Gamekit.Service;
using UnityEngine;

namespace Resources.Scripts
{
    public class GameApplication : MonoBehaviour
    {
        private GameObject _container;
        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            _container = new GameObject("container");
            _container.transform.SetParent(gameObject.transform, true);
            GameWorldService gameWorldService = _container.AddComponent<GameWorldService>();
            gameWorldService.Configure();
        }

        [PublicAPI]
        public void Restart()
        {
            Destroy(_container);
            StartGame();
        }
    }
}
