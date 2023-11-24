using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V0_MonsterRootlogic : MonoBehaviour
{
    public RootConstructionManagerMono m_rootConstructor;
    public EmptySpaceSeekerMono m_emptySpaceSeeker;
    public FoodSeekerMono m_foodSeeker;


    public GameObject m_targetObject;
    public float m_randomAngleIfNotFound = 10;
    public float m_randomAngleIfTracked= 30;

    public Transform m_roomTopLeft;
    public Transform m_roomDownRight;

    public float m_lookForward=0.2f;

    public Transform m_emptyAnchorFocus;

    public void CreateNextRootWithContext()
    {
       
        GameObject lastCreated = m_rootConstructor.m_lastCreatedRoot;
        if (lastCreated.transform == null)
            return;
        Vector3 lastCreatedPosition = lastCreated.transform.position;
        m_foodSeeker.RefreshFoodInScene();
        if (m_foodSeeker.HasFood()) {
            m_foodSeeker.GetClosestFood(lastCreatedPosition, out RootFoodTag food)
               ;
            m_targetObject = food.gameObject;
            m_emptyAnchorFocus.position = m_targetObject.transform.position;
        }
        m_emptyAnchorFocus.gameObject.SetActive(m_foodSeeker.HasFood());

        m_emptySpaceSeeker.DoCheck();
        if (m_targetObject != null)
        {
            Vector3 destination = m_targetObject.transform.position;
            if (m_emptySpaceSeeker.HasValidePoint()) {
               m_emptySpaceSeeker.GetClosePointOf(destination, out destination);
            }
            m_rootConstructor.CreateRootInDirection(destination,
                 out GameObject createdRoot);
            Eloi.E_DrawingUtility.DrawLines(3, Color.yellow, m_targetObject.transform.position, destination, m_rootConstructor.m_lastCreatedRoot.transform.position);
            
        }
        else {
            if (m_emptySpaceSeeker.HasValidePoint())
            {
                m_emptySpaceSeeker.GetCenterOfValidePoint(out Vector3 point);
                Eloi.E_DrawingUtility.DrawLines(3, Color.cyan, 
                     point, m_rootConstructor.m_lastCreatedRoot.transform.position);

                m_rootConstructor.CreateRootInDirectionWithRandom(point, m_randomAngleIfNotFound, out GameObject createdRoot);
            }
            else { 
                // Look for the last empty space of the room with the bool grid.
                //m_rootConstructor.CreateRootInDirectionRandomlyForward(m_randomAngleIfNotFound, out GameObject createdRoot);
            }
        }
        

    }


}
