using Enums;
using Models;
using UnityEngine;
using Views;

namespace Controllers.Character
{
    public class CharacterController : BaseController
    {
        private CharacterView _characterView;

        public void CreateCharacter(CharacterModel characterModel, Transform point)
        {
            _characterView = SystemController.resourceManager.InstantiatePrefabByName<CharacterView>(GameObjectTypes.Beaver.ToString());
            _characterView.transform.position = point.position;
            _characterView.DoTaskAction += NewTask;
            _characterView.SetModel(characterModel);
        }

        public void Destroy()
        {
            _characterView.DoTaskAction -= NewTask;
            _characterView = null;
            Object.Destroy(_characterView);
        }

        private void NewTask()
        {
            var newTask = SystemController.taskController.NewTask(this);

            _characterView.NewTask(newTask);
        }
    }
}
