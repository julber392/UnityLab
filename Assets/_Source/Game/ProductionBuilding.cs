using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using UnityEngine.UI;

namespace Game
{
    public class ProductionBuilding : MonoBehaviour
    {
        
        [SerializeField] 
        private Button button;
        [SerializeField] 
        private Slider timerSlider;
        private bool stopTimer = false;
        [SerializeField]
        private GameResource _GameResource;
        [SerializeField]
        private float ProductionTime;

        private GameResource _prodlvl;

        void Awake()
        {
            button.onClick.AddListener(() => StartCoroutine(IdleFarm(_GameResource,1,ProductionTime)));
        }
        

        // ReSharper disable Unity.PerformanceAnalysis
        IEnumerator IdleFarm(GameResource resource,int value,float time)
        {
            button.interactable = false;
            if ((resource == GameResource.FoodProdLvl) || (resource == GameResource.HumansProdLvl) ||
                (resource == GameResource.WoodProdLvl) || (resource == GameResource.StoneProdLvl) ||
                (resource == GameResource.GoldProdLvl))
            {
                
            }

            switch (resource)
            {
                case GameResource.Humans:
                    _prodlvl = GameResource.HumansProdLvl;
                    time = time * GameManager._resourceBank.GetResource(_prodlvl);
                    break;
                case GameResource.Food:
                    _prodlvl = GameResource.FoodProdLvl;
                    time = time * GameManager._resourceBank.GetResource(_prodlvl);
                    break;
                case GameResource.Wood:
                    _prodlvl = GameResource.WoodProdLvl;
                    time = time * GameManager._resourceBank.GetResource(_prodlvl);
                    break;
                case GameResource.Stone:
                    _prodlvl = GameResource.StoneProdLvl;
                    time = time * GameManager._resourceBank.GetResource(_prodlvl);
                    break;
                case GameResource.Gold:
                    _prodlvl = GameResource.GoldProdLvl;
                    time = time * GameManager._resourceBank.GetResource(_prodlvl);
                    break;
                case GameResource.HumansProdLvl:
                    stopTimer = true;
                    break;
                case GameResource.FoodProdLvl:
                    stopTimer = true;
                    break;
                case GameResource.WoodProdLvl:
                    stopTimer = true;
                    break;
                case GameResource.StoneProdLvl:
                    stopTimer = true;
                    break;
                case GameResource.GoldProdLvl:
                    stopTimer = true;
                    break;
                
            }
            timerSlider.maxValue = time;
            timerSlider.value = time;
            while (stopTimer==false)
            {
                time -= Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
                if (time <= 0)
                {
                    stopTimer = true;
                }

                if (stopTimer == false)
                {
                    timerSlider.value = time;
                }
                    
            }
            stopTimer = false;
            GameManager._resourceBank.ChangeResource(resource,value);
            button.interactable = true;
        }
    }
}
