using System;
using Enums;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class LetterModel
    {
        public LetterType letterType;
        public Sprite letterSprite;
        public LetterSettings letterSettings;
    }
}
