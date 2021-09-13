using System.Linq;
using Enums;
using Models;
using UnityEngine;

namespace Controllers.Letter
{
    public class LetterManager : BaseController
    {
        private AllLetter _allLetter;

        private int _countErrorLetter;
        private int _maxErrorLetter = 3;

        public LetterManager()
        {
            _allLetter = SystemController.resourceManager.InstantiateScriptableObjectByName<AllLetter>(
                ScriptableTypes.AllLetter.ToString());
        }

        public LetterModel GetLetterModel()
        {
            if (_countErrorLetter >= _maxErrorLetter)
            {
                var randomTask = SystemController.taskController.GetRandomTask();
                _countErrorLetter = 0;

                return _allLetter.letterModels.FirstOrDefault(l =>
                    l.letterType == randomTask);
            }

            var randomLetterModelIndex = Random.Range(0, _allLetter.letterModels.Length);

            _countErrorLetter++;

            return _allLetter.letterModels[randomLetterModelIndex];
        }

        public LetterType GetRandomLetter()
        {
            var randomIndex = Random.Range(0, _allLetter.letterModels.Length);
            return _allLetter.letterModels[randomIndex].letterType;
        }
    }
}
