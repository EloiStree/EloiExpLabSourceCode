using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creeChenille : MonoBehaviour
{
    public float Temps = 2;
    //public Vector3 angleRotation = Vector3.zero;
    public GameObject[] Player;

    public Transform[] Point;

    public Transform RootCenterPoint;
    public float Destruction = 20;
    public float CreationDistance=0.2f;

    public AnimationCurve m_powerOfFollowing;
    public float m_rangeOfEffect;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("creeObjet", Temps);
    }

    //[SerializeField] Transform target;
    // Update is called once per frame
    public Vector3 Norm;
    public RootFoodTag[] tagsOfFoodToTrack;
    
    

    void creeObjet()
    {

        tagsOfFoodToTrack = GameObject.FindObjectsOfType<RootFoodTag>();
        if (tagsOfFoodToTrack.Length > 0) { 
            float maxDistance = float.MaxValue;
            RootFoodTag closeFood = null;


            for (int i = 0; i < tagsOfFoodToTrack.Length; i++)
            {
                float distance = (tagsOfFoodToTrack[i].transform.position - this.transform.position).magnitude;
                
                if(distance < maxDistance)
                {
                    maxDistance = distance;
                    closeFood = tagsOfFoodToTrack[i];
                }
            }

            int monRandom = Random.Range(0, Point.Length);

            RootCenterPoint = Point[monRandom];

            
            RootNodeFactory.InfoPoint.Add( new Coordonate( RootCenterPoint.position.x, RootCenterPoint.position.y, RootCenterPoint.position.z));

            //Permet de voir les coordonne du debut de l'arbre
            //Debug.Log( "Coordonne " +  RootNodeFactory.InfoPoint[RootNodeFactory.InfoPoint.Count - 1].X + " ; "+ RootNodeFactory.InfoPoint[RootNodeFactory.InfoPoint.Count - 1].Y  + " ; "+ RootNodeFactory.InfoPoint[RootNodeFactory.InfoPoint.Count - 1].X) ;



            Vector3 direction = closeFood.transform.position - RootCenterPoint.position;
            float playerDistance = direction.magnitude;
            if (playerDistance < m_rangeOfEffect)
            {
                float rangeEffectPercent = playerDistance / m_rangeOfEffect;

                float effectPower = m_powerOfFollowing.Evaluate(rangeEffectPercent);
                //float angle = Mathf.Atan2(direction.y, direction.x);
                //direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                Norm = direction.normalized;
                // Vector3 point = RootCenterPoint.position + (direction.normalized * CreationDistance);

                Vector3 point = RootCenterPoint.position + (Norm * CreationDistance* effectPower);

                //point = point + angleRotation;

                Debug.DrawLine(RootCenterPoint.position, RootCenterPoint.position + (Norm), Color.red, 0.1f);
                //this.transform.forward = direction;


                //creationProcedurale.creationDObjet(point, Quaternion.LookRotation(direction, Vector3.up), out GameObject cree);

                RootNodeFactory.creationDObjet(point, Quaternion.LookRotation(direction, Vector3.up), out GameObject cree);


                Eloi.E_UnityRandomUtility.GetRandomN2M(-360, 360, out float rotation);
                cree.transform.Rotate(new Vector3(0, 0, rotation), Space.Self);
            }
        }
        else {
            // to code random moveµ
            Eloi.E_UnityRandomUtility.GetRandomVector3Direction(out Vector3 dir);
            Vector3 randomPos = RootCenterPoint.position + dir* CreationDistance;
            RootNodeFactory.creationDObjet(randomPos, Quaternion.LookRotation(dir, Vector3.up), out GameObject cree);
        }
      
      





       // creationProcedurale.creationDObjet(point, Quaternion.LookRotation(direction, RootCenterPoint.up, out GameObject cree);

    }

    private void Reset()
    {
        RootCenterPoint = this.transform;
    }

}
