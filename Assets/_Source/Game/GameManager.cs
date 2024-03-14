using Core;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Game
{
    public class GameManager:MonoBehaviour
    {
        public static ResourceBank _resourceBank;
        private void Awake()
        {
            StartGame();
        }

        private void StartGame()
        {
            _resourceBank = new ResourceBank(10, 5, 5, 0, 0);
        }
    }
}
