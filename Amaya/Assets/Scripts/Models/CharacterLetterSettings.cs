using System;
using Enums;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu(fileName = "CharacterLetter", menuName = "Character/LetterSettings", order = 0)]
    public class CharacterLetterSettings : ScriptableObject
    {
        public CharacterLetter[] characterLetters;
    }

    [Serializable]
    public class CharacterLetter
    {
        public LetterType letterType;
        public Sprite letterSprite;
    }
}
