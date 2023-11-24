using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public interface IGazableObjectTag : IInteractableObject
{
}



public class GazableObjectMono : InteractableObjectMono, IGazableObjectTag  
{}
