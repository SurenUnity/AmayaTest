using System.Collections.Generic;
using System.Linq;
using Controllers.Letter;
using Enums;
using Models;
using UnityEngine;

namespace Controllers.Fabrics
{
    public class LetterFabric : BaseController
    {
        private List<LetterController> _letters = new List<LetterController>();

        private int _offset = 5;
        private int _startLetterCount = 10;

        public LetterFabric()
        {
            CreateLetter();
        }

        public void RefreshLetter(LetterController letterController)
        {
            var lastFreeLetterIndex = _letters.Where(l => l.GetState() == LetterState.Free).Max(l=>l.index);
            var lastFreeLetter = _letters.FirstOrDefault(l=>l.index == lastFreeLetterIndex);
            var lastLetterPosition = lastFreeLetter.GetPosition();

            var newPosition = new Vector3(lastLetterPosition.x - _offset, lastLetterPosition.y);
            letterController.SetPosition(newPosition);

            lastFreeLetter.SetIndex(letterController.index);
            letterController.SetIndex(lastFreeLetterIndex);

            var model = SystemController.letterManager.GetLetterModel();
            letterController.SetModel(model);
        }

        private void CreateLetter()
        {
            for (int i = 0; i < _startLetterCount; i++)
            {
                var letter = new LetterController(i);
                var model = SystemController.letterManager.GetLetterModel();
                letter.SetModel(model);
                if (i > 0)
                {
                    var letterPosition = _letters[i - 1].GetPosition();
                    var newPosition = new Vector3(letterPosition.x - _offset, letterPosition.y);
                    letter.SetPosition(newPosition);
                }
                else
                {
                    letter.SetPosition(SystemController.world.startLetterPoint.localPosition);
                }
                _letters.Add(letter);
            }
        }
    }
}
