using UnityEngine;

namespace Models
{
    [CreateAssetMenu(fileName = "AllLetter", menuName = "Letter/LettersData", order = 0)]
    public class AllLetter : ScriptableObject
    {
        public LetterModel[] letterModels;
    }
}
