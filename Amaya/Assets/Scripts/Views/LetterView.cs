using System;
using DG.Tweening;
using Enums;
using Models;
using UnityEngine;

namespace Views
{
    public class LetterView : MonoBehaviour
    {
        public event Action<Collider2D> OnTriggerAction;
        public event Action OnEndDrag;
        public event Action OnEndPoint;

        [HideInInspector]
        public LetterState state = LetterState.Free;

        [SerializeField] private SpriteRenderer _letterSprite;

        public LetterModel letterModel { get; private set; }

        private Vector3 _offset;

        private Vector3 _stopPoint;

        private float _offsetForEndPoint = 1;
        private float _scaleDrag = 1.25f;

        public void SetStopPoint(Vector3 stopPoint)
        {
            _stopPoint = stopPoint;
        }

        public void SetModel(LetterModel letterModel)
        {
            this.letterModel = letterModel;
            _letterSprite.sprite = letterModel.letterSprite;
        }

        private void Update()
        {
            if (state == LetterState.Free)
            {
                transform.position +=
                    transform.right * letterModel.letterSettings.speed * Time.deltaTime;

                if (Vector3.Distance(transform.localPosition, _stopPoint) <= _offsetForEndPoint)
                {
                    state = LetterState.NeedRefresh;
                    OnEndPoint?.Invoke();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Enter");
            OnTriggerAction?.Invoke(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("Exit");
            OnTriggerAction?.Invoke(null);
        }

        private void OnMouseDown()
        {
            state = LetterState.Dragging;
            _offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            transform.DOScale(_scaleDrag, 0.2f).From(1);
        }

        private void OnMouseDrag()
        {
            Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + _offset;
            transform.position = curPosition;
        }

        private void OnMouseUp()
        {
            transform.DOScale(1, 0.2f).From(_scaleDrag);
            state = LetterState.Free;
            OnEndDrag?.Invoke();
        }
    }
}
