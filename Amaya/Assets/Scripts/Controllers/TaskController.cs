using System.Collections.Generic;
using System.Linq;
using Enums;
using UnityEngine;
using CharacterController = Controllers.Character.CharacterController;

namespace Controllers
{
    public class TaskController : BaseController
    {
        private Dictionary<CharacterController, LetterType> _currentTasks = new Dictionary<CharacterController, LetterType>();

        public LetterType NewTask(CharacterController characterController)
        {
            while (true)
            {
                var randomLetter = SystemController.letterManager.GetRandomLetter();
                if (_currentTasks.ContainsValue(randomLetter))
                {
                    continue;
                }

                _currentTasks[characterController] = randomLetter;
                return randomLetter;
            }
        }

        public LetterType GetRandomTask()
        {
            var randomTaskIndex = Random.Range(0, _currentTasks.Count);
            return _currentTasks.ElementAt(randomTaskIndex).Value;
        }
    }
}
