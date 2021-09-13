using System.Collections.Generic;
using Controllers.Character;
using Models;

namespace Controllers.Fabrics
{
    public class CharacterFabric : BaseController
    {
        private int characterCount = 3;

        private List<CharacterController> _characterControllers = new List<CharacterController>();

        public CharacterFabric()
        {
            for (int i = 0; i < characterCount; i++)
            {
                var character = new CharacterController();
                var characterModel = new CharacterModel
                {
                    correctLetter = SystemController.taskController.NewTask(character)
                };
                character.CreateCharacter(characterModel, SystemController.world.characterPositions[i]);
                _characterControllers.Add(character);
            }
        }
    }
}
