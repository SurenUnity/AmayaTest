using DG.Tweening;
using Enums;
using Interfaces;
using Models;
using UnityEngine;
using Views;

namespace Controllers.Letter
{
    public class LetterController : BaseController
    {
        public int index;

        private LetterView _letter;

        private float _offsetForEndPoint = 1;

        private Collider2D _collider2D;

        public LetterController(int index)
        {
            this.index = index;

            _letter = SystemController.resourceManager.InstantiatePrefabByName<LetterView>(GameObjectTypes.Letter
                .ToString());
            _letter.SetStopPoint(SystemController.world.endLetterPoint.position);
            _letter.OnEndPoint += RefreshLetter;
            _letter.OnTriggerAction += CheckCollider;
            _letter.OnEndDrag += TryDoTask;
        }

        public void SetPosition(Vector3 position)
        {
            _letter.transform.position = position;
        }

        public void SetModel(LetterModel letterModel)
        {
            _letter.SetModel(letterModel);
            _letter.state = LetterState.Free;
        }

        public Vector3 GetPosition()
        {
            return _letter.transform.position;
        }

        public void SetIndex(int index)
        {
            this.index = index;
        }

        public void RefreshLetter()
        {
            _collider2D = null;
            _letter.state = LetterState.NeedRefresh;
            SystemController.letterFabric.RefreshLetter(this);
        }

        public LetterState GetState()
        {
            return _letter.state;
        }

        private void CheckCollider(Collider2D collider2D)
        {
            _collider2D = collider2D;
        }

        private void TryDoTask()
        {
            if (_collider2D == null)
            {
                RefreshLetter();
                return;
            }

            var correctCharacterForTask = _collider2D.GetComponent<ICorrectLetter>();
            if (correctCharacterForTask == null)
            {
                RefreshLetter();
                return;
            }

            var isDone = correctCharacterForTask.DoTask(_letter.letterModel.letterType);
            if (isDone)
            {
                _letter.transform.DOScale(0, 0.2f).From(1).OnComplete(()=>
                {
                    RefreshLetter();
                    _letter.transform.DOScale(1, 0.2f).From(0);
                });
            }
            else
            {
                RefreshLetter();
            }
        }
    }
}
