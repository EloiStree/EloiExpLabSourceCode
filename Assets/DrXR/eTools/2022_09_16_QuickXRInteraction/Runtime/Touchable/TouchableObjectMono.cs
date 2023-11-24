using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public interface ITouchableObjectTag: IInteractableObject
{
}

public class TouchableObjectMono : InteractableObjectMono , ITouchableObjectTag { }