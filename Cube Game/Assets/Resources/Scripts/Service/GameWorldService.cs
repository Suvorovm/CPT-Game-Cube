using UnityEngine;

namespace Resources.Scripts.Service
{
    public class GameWorldService : MonoBehaviour
    {
        private const string GAME_WORLD_PATH = "Embeded/Prefab/GameWorld";
       
        private GameObject _world;

        public void Configure()
        {
            Object prefab = UnityEngine.Resources.Load(GAME_WORLD_PATH);
            _world = Instantiate(prefab, Vector3.zero, Quaternion.Euler(Vector3.zero)) as GameObject;
            _world.transform.SetParent(gameObject.transform);
        }
        
    }
}