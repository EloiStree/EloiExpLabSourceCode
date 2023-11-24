using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSeekerMono : MonoBehaviour
{

    public RootFoodTag [] m_food;


    public void RefreshFoodInScene()
    {
        Eloi.E_SearchInSceneUtility.TryToFetchWithActiveInScene<RootFoodTag>(ref m_food);
    }

    public void GetClosestFood(Vector3 originePoint, out RootFoodTag bestTarget)
        {

            bestTarget = null;

            float closeDistance = float.MaxValue;
            for (int i = 0; i < m_food.Length; i++)
            {
                float distance = (originePoint - m_food[i].transform.position).magnitude;
                if (distance < closeDistance)
                {
                    closeDistance = distance;
                    bestTarget = m_food[i];
                }
            }
        }
    public bool HasFood()
    {
        return m_food.Length > 0;
    }
}
