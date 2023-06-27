using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class MenuButton : MonoBehaviour
    {
        public RectTransform MyRectTransform => _myRectTransform;
        public event Action OnProcessButton;
        
        [SerializeField] private RectTransform _myRectTransform;
        [SerializeField] private TextMeshProUGUI _buttonTextMesh;

        private bool _highlighted;

        private string _originalText;

        private void Awake()
        {
            _originalText = _buttonTextMesh.text;
        }

        public void Highlight()
        {
            if (_highlighted)
                return;
            
            _highlighted = true;
            
            _buttonTextMesh.text = "<b>> " + _originalText + " <</b>";
        }

        public void Unhighlight()
        {
            if (!_highlighted)
                return;
            
            _highlighted = false;
            
            _buttonTextMesh.text = _originalText;
        }

        public void ProcessButton()
        {
            OnProcessButton?.Invoke();
        }
    }
}
