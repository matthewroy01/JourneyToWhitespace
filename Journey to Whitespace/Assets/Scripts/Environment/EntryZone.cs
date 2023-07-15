using System;
using System.Collections.Generic;
using Ship;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Environment
{
    public class EntryZone : MonoBehaviour
    {
        [SerializeField] private EntryZoneData _entryZoneData;
        [SerializeField] private TextMeshProUGUI _infoTextMesh;
        [SerializeField] private float _distanceRequired;
        [SerializeField] private float _updateTime;
        [SerializeField] private float _extraDistance;
        [Header("Corners and Fill")]
        [SerializeField] private Transform _cornerTopLeft;
        [SerializeField] private Transform _cornerTopRight;
        [SerializeField] private Transform _cornerBottomRight;
        [SerializeField] private Transform _cornerBottomLeft;
        [SerializeField] private Transform _fill;
        [SerializeField] private float _expandAmount = 1.0f;
        [SerializeField] private float _expandSpeed;
        private float _timer;
        private string _infoText;
        private ShipManager _shipManager;
        private Vector3 _shipManagerPosition;
        private float _sqrDistance;
        private float _distance;
        private string _fakeDistance;
        private readonly List<char> _charsToRemove = new() { '.', ',' };
        private float _targetExpandAmount = 0.0f;

        private void Awake()
        {
            _infoText = "Zone of Entry: " + _entryZoneData.Name + "\n" + "Affiliation: " + _entryZoneData.Affiliation +
                        "\n" + "Sector: " + _entryZoneData.Sector + "\n" + "Distance: ";

            _shipManager = FindObjectOfType<ShipManager>();
        }

        private void Update()
        {
            UpdateText();
            Expand();
        }

        private void UpdateText()
        {
            _shipManagerPosition = _shipManager.transform.position;
            
            _sqrDistance = Vector3.SqrMagnitude(transform.position - _shipManagerPosition);

            if (_sqrDistance > _distanceRequired * _distanceRequired)
            {
                _timer = 0.0f;
                return;
            }

            _timer += Time.deltaTime;

            if (_timer < _updateTime)
            {
                return;
            }

            _timer = 0.0f;

            _distance = Vector3.Distance(transform.position, _shipManagerPosition);
            
            _fakeDistance = (_distance + _extraDistance).ToString("0.00");

            foreach (char c in _charsToRemove)
            {
                _fakeDistance = _fakeDistance.Replace(c.ToString(), string.Empty);
            }

            _infoTextMesh.text = _infoText + _fakeDistance + "km";
        }

        private void Expand()
        {
            ExpandSpecificCorner(_cornerTopLeft, -1.0f, 1.0f);
            ExpandSpecificCorner(_cornerTopRight, 1.0f, 1.0f);
            ExpandSpecificCorner(_cornerBottomRight, 1.0f, -1.0f);
            ExpandSpecificCorner(_cornerBottomLeft, -1.0f, -1.0f);

            _fill.localScale = Vector3.Lerp(_fill.localScale, (Vector3.one * 4.0f) + (Vector3.one * _targetExpandAmount),
                Time.deltaTime * _expandSpeed);
        }

        private void ExpandSpecificCorner(Transform corner, float xMultiplier, float yMultiplier)
        {
            Vector3 position = corner.transform.localPosition;
            
            corner.transform.localPosition = Vector3.Lerp(position,new Vector3(_targetExpandAmount * xMultiplier,
                _targetExpandAmount * yMultiplier, position.z), _expandSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _targetExpandAmount = _expandAmount;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _targetExpandAmount = 0.0f;
            }
        }
    }
}