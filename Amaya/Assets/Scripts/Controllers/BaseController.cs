namespace Controllers
{
    public class BaseController
    {
        private static SystemController _systemController;
        protected SystemController SystemController => _systemController;

        public static void Init(SystemController systemController)
        {
            _systemController = systemController;
        }

        public virtual void Start()
        {

        }

        public virtual void Update(float deltaTime)
        {

        }

        public virtual void FixedUpdate(float fixedDeltaTime)
        {

        }
    }
}
