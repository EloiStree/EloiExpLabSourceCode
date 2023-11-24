using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class INamedBooleanUnityEventGet : UnityEvent<INamedBooleanGet> { }

public delegate void INamedBooleanDelegateEventGet(INamedBooleanGet value);


[System.Serializable]
public class INamedBooleanUnityEvent : UnityEvent<INamedBoolean> { }

public delegate void INamedBooleanDelegateEvent(INamedBoolean value);
