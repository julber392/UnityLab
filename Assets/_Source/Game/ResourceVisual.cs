using System;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ResourceVisual : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI _valueText;
        [SerializeField]
        public GameResource _gameResource;
        
        private void OnEnable()
        {
            GameManager._resourceBank.OnValueChanged += UpdateValue;
        }
        private void OnDisable()
        {
            GameManager._resourceBank.OnValueChanged -= UpdateValue;
        }
        

        private void UpdateValue()
        {
            _valueText.text = GameManager._resourceBank.GetResource(_gameResource).ToString();
        }
    }
}