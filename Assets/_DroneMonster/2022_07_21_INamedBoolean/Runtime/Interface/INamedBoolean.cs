using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Named boolean is just that:an access to a string and a value that is boolean. Don't even have to be a class can be an index in some arrays.
/// This is the basic of the project OMI. Because reduce all to boolean allows to have a large API toolbox that don't to change through time.
/// </summary>
public interface INamedBoolean: INamedBooleanGet
{}
public interface INamedBooleanGet
{
    public void GetName(out string name);
    public void GetValue(out bool value);
    public void GetNameRefInContainer(ref string name);
    public void GetValueRefInConainer(ref bool value);
    public string GetName();
    public bool GetValue();
}

public interface INamedBooleanSettable : INamedBoolean, INamedBooleanSet
{}

public interface INamedBooleanSet
{
    public void SetName(in string name);
    public void SetValue(in bool value);
}
