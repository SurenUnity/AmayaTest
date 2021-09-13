using UnityEngine;

namespace Models
{
    [CreateAssetMenu(fileName = "LetterSettings", menuName = "Letter/Settings", order = 0)]
    public class LetterSettings : ScriptableObject
    {
        public float speed = 5;
    }
}
