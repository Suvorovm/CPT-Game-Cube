using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Resources.Scripts.Gamekit.Controller;
using Resources.Scripts.Gamekit.Model;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Resources.Scripts.Gamekit.Service
{
    public class GameWorldService : MonoBehaviour
    {
        private const string GAME_WORLD_PATH = "Embeded/Prefab/GameWorld";
        private readonly Dictionary<GameObjectType, ControllerData> _controllers = new Dictionary<GameObjectType, ControllerData>();

        private GameObject _world;

        public void Configure()
        {
            InitializeControllers();
            CreateWorld();
            CreateControllers();
        }

        private void CreateControllers()
        {
            foreach (GameObject gameObj in GetSceneGameObject()) {
                GameModel gameModel = gameObj.GetComponent<GameModel>();
                if (gameModel == null) {
                    continue;
                }
                ControllerData data = _controllers[gameModel.GameObjectType];
                Component component = gameObj.AddComponent(data.Controller);
                _controllers[gameModel.GameObjectType].Init(gameModel, component);
            }
        }

        private void CreateWorld()
        {
            Object prefab = UnityEngine.Resources.Load(GAME_WORLD_PATH);
            _world = Instantiate(prefab, Vector3.zero, Quaternion.Euler(Vector3.zero)) as GameObject;
            _world.name = prefab.name;
            _world.transform.SetParent(gameObject.transform);
        }

        private void InitializeControllers()
        {
            _controllers[GameObjectType.PLAYER] = new ControllerData(InitController<PlayerModel, PlayerController>, typeof(PlayerController));
            _controllers[GameObjectType.GATES] = new ControllerData(InitController<GateModel, GateController>, typeof(GateController));
            _controllers[GameObjectType.SPHERE] = new ControllerData(InitController<SphereModel, SphereController>, typeof(SphereController));
        }

        [CanBeNull]
        private List<GameObject> GetSceneGameObject()
        {
            Object[] findObjectsOfType = FindObjectsOfType(typeof(GameObject));
            return findObjectsOfType.OfType<GameObject>().ToList();
        }

        private void InitController<TM, TC>(GameModel gameModel, object controllerType)
                where TM : GameModel
                where TC : Initializable
        {
            try {
                ((TC) controllerType).Init((TM) gameModel);
            } catch (Exception e) {
                Debug.LogError($"Not valid controller or model {e}");
                throw;
            }
        }
    }

    internal class ControllerData
    {
        public Type Controller { get; private set; }
        public readonly Action<GameModel, Object> Init;

        public ControllerData(Action<GameModel, Object> init, Type controller)
        {
            Init = init;
            Controller = controller;
        }
    }
}