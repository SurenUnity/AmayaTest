using System;
using System.Linq;
using Enums;
using Interfaces;
using Models;
using UnityEngine;

namespace Views
{
    public class CharacterView : MonoBehaviour, ICorrectLetter
    {
        public event Action DoTaskAction;
        public CharacterModel characterModel { get; private set; }

        [SerializeField] private SpriteRenderer _letterSprite;
        [SerializeField] private CharacterLetterSettings _characterLetter;

        public bool DoTask(LetterType letterType)
        {
            if (letterType != characterModel.correctLetter)
            {
                return false;
            }

            DoTaskAction?.Invoke();
            return true;

        }

        public void SetModel(CharacterModel characterModel)
        {
            this.characterModel = characterModel;
            SetTaskSprite(characterModel.correctLetter);
        }

        public void NewTask(LetterType letterType)
        {
            characterModel.correctLetter = letterType;
            SetTaskSprite(letterType);
        }

        public void SetTaskSprite(LetterType letterType)
        {
            var correctSprite = _characterLetter.characterLetters.FirstOrDefault(l => l.letterType == letterType)?.letterSprite;
            _letterSprite.sprite = correctSprite;
        }
    }
}
