using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Management;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _background;
        [SerializeField] private RectTransform _slideIn;
        [SerializeField] private float _animationDuration;
        [SerializeField] private ParticleSystem _binaryParts;
        [Header("Buttons")]
        [SerializeField] private MenuButton _continueButton;
        [SerializeField] private MenuButton _returnButton;
        [SerializeField] private MenuButton _settingsButton;
        [SerializeField] private MenuButton _quitButton;

        private readonly List<MenuButton> _menuButtons = new();
        private Coroutine _menuCoroutine;
        private bool _open;
        private bool _animating;
        private Vector2 _mousePosition;
        private MenuButton _highlightedButton;

        private void Awake()
        {
            _background.DOFade(0.0f, 0.0f);
            _slideIn.DOMoveX(-_slideIn.rect.width, 0.0f);
            
            _menuButtons.Add(_continueButton);
            _menuButtons.Add(_returnButton);
            _menuButtons.Add(_settingsButton);
            _menuButtons.Add(_quitButton);
        }

        private void OnEnable()
        {
            InputManager.PausePerformed += OnPausePerformed;
            InputManager.LeftClickPerformed += OnLeftClickPerformed;
            _continueButton.OnProcessButton += CloseMenu;
            // TODO: add event for return button
            // TODO: add event for settings button
            _quitButton.OnProcessButton += QuitToDesktop;
        }

        private void OnDisable()
        {
            InputManager.PausePerformed -= OnPausePerformed;
            InputManager.LeftClickPerformed -= OnLeftClickPerformed;
            _continueButton.OnProcessButton -= CloseMenu;
            // TODO: remove event from return button
            // TODO: remove event from settings button
            _quitButton.OnProcessButton -= QuitToDesktop;
        }
        
        private void OnPausePerformed()
        {
            if (_open)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }

        private void OnLeftClickPerformed()
        {
            if (!_open || _animating)
                return;
            
            if (_highlightedButton == null)
                return;

            _highlightedButton.ProcessButton();
        }

        public void MyUpdate()
        {
            CheckMouseOverlap();
        }

        private void CheckMouseOverlap()
        {
            if (!_open || _animating)
                return;

            _mousePosition = Mouse.current.position.ReadValue();

            bool foundButtonToHighlight = false;
            
            foreach (MenuButton menuButton in _menuButtons)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(menuButton.MyRectTransform, _mousePosition) && !foundButtonToHighlight)
                {
                    menuButton.Highlight();
                    
                    _highlightedButton = menuButton;
                    foundButtonToHighlight = true;
                }
                else
                {
                    menuButton.Unhighlight();
                }
            }

            if (!foundButtonToHighlight)
            {
                _highlightedButton = null;
            }
        }

        private void ClearOverlaps()
        {
            foreach (MenuButton menuButton in _menuButtons)
            {
                menuButton.Unhighlight();
            }

            _highlightedButton = null;
        }

        private void OpenMenu()
        {
            _open = true;
            _animating = true;

            if (_menuCoroutine != null)
            {
                StopCoroutine(_menuCoroutine);
            }
            _menuCoroutine = StartCoroutine(OpenMenuRoutine());
        }

        private void CloseMenu()
        {
            _open = false;
            _animating = true;

            ClearOverlaps();
            
            if (_menuCoroutine != null)
            {
                StopCoroutine(_menuCoroutine);
            }
            _menuCoroutine = StartCoroutine(CloseMenuRoutine());
        }

        private void QuitToDesktop()
        {
            Application.Quit();
        }

        private IEnumerator OpenMenuRoutine()
        {
            float endPos = 0.0f;
            
            _background.DOFade(1.0f, _animationDuration);
            _slideIn.DOMoveX(endPos, _animationDuration).SetEase(Ease.OutBack);
            
            _binaryParts.Play();
            
            yield return new WaitForSeconds(_animationDuration);

            _slideIn.anchoredPosition = new Vector2(endPos, _slideIn.anchoredPosition.y);

            // TODO: enable input on buttons
            
            _animating = false;
        }

        private IEnumerator CloseMenuRoutine()
        {
            // TODO: disable input on buttons
            
            float endPos = -_slideIn.rect.width;
            
            _background.DOFade(0.0f, _animationDuration);
            _slideIn.DOMoveX(-_slideIn.rect.width, _animationDuration).SetEase(Ease.InBack);
            
            yield return new WaitForSeconds(_animationDuration);
            
            _slideIn.anchoredPosition = new Vector2(endPos, _slideIn.anchoredPosition.y);

            _animating = false;
        }
    }
}
