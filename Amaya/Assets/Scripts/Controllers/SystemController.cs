using Controllers.Fabrics;
using Controllers.Letter;
using Views;

namespace Controllers
{
    public class SystemController
    {
        public ResourceManager resourceManager;

        public World world;

        public TaskController taskController;
        public LetterManager letterManager;
        public LetterFabric letterFabric;
        public CharacterFabric characterFabric;


        public SystemController(World world)
        {
            BaseController.Init(this);
            this.world = world;
            resourceManager = new ResourceManager();
            Init();
        }

        private void Init()
        {
            letterManager = new LetterManager();
            taskController = new TaskController();
            characterFabric = new CharacterFabric();
            letterFabric = new LetterFabric();
        }


    }
}
