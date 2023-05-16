using UnityEngine;
using System.Collections.Generic;

public class PrototypeExample : MonoBehaviour
{
    void Start()
    {
        // Crear prototipos de marcas de celulares con modelos dentro
        ApplePrototype applePrototype = new ApplePrototype("iPhone X");
        applePrototype.AddModel("iPhone XR");

        SamsungPrototype samsungPrototype = new SamsungPrototype("Galaxy S10");
        samsungPrototype.AddModel("Galaxy S20");
        samsungPrototype.AddModel("Galaxy A70");

        HuaweiPrototype huaweiPrototype = new HuaweiPrototype("P30");
        huaweiPrototype.AddModel("P40");

        // Clonar los prototipos y mostrar la información
        ApplePrototype appleClone = (ApplePrototype)applePrototype.Clone();
        Debug.Log($"Apple: {appleClone.Name}");
        foreach (string model in appleClone.Models)
        {
            Debug.Log($"- {model}");
        }

        SamsungPrototype samsungClone = (SamsungPrototype)samsungPrototype.Clone();
        Debug.Log($"Samsung: {samsungClone.Name}");
        foreach (string model in samsungClone.Models)
        {
            Debug.Log($"- {model}");
        }

        HuaweiPrototype huaweiClone = (HuaweiPrototype)huaweiPrototype.Clone();
        Debug.Log($"Huawei: {huaweiClone.Name}");
        foreach (string model in huaweiClone.Models)
        {
            Debug.Log($"- {model}");
        }
    }
}

// Interfaz del prototipo de celular
public interface ICellPhonePrototype
{
    string Name { get; }
    ICellPhonePrototype Clone();
}

// Implementación concreta del prototipo de celular de Apple
public class ApplePrototype : ICellPhonePrototype
{
    public string Name { get; }
    public List<string> Models { get; }

    public ApplePrototype(string name)
    {
        Name = name;
        Models = new List<string>();
    }

    public void AddModel(string model)
    {
        Models.Add(model);
    }

    public ICellPhonePrototype Clone()
    {
        ApplePrototype clone = new ApplePrototype(Name);
        clone.Models.AddRange(Models);
        return clone;
    }
}

// Implementación concreta del prototipo de celular de Samsung
public class SamsungPrototype : ICellPhonePrototype
{
    public string Name { get; }
    public List<string> Models { get; }

    public SamsungPrototype(string name)
    {
        Name = name;
        Models = new List<string>();
    }

    public void AddModel(string model)
    {
        Models.Add(model);
    }

    public ICellPhonePrototype Clone()
    {
        SamsungPrototype clone = new SamsungPrototype(Name);
        clone.Models.AddRange(Models);
        return clone;
    }
}

// Implementación concreta del prototipo de celular de Huawei
public class HuaweiPrototype : ICellPhonePrototype
{
    public string Name { get; }
    public List<string> Models { get; }

    public HuaweiPrototype(string name)
    {
        Name = name;
        Models = new List<string>();
    }

    public void AddModel(string model)
    {
        Models.Add(model);
    }

    public ICellPhonePrototype Clone()
    {
        HuaweiPrototype clone = new HuaweiPrototype(Name);
        clone.Models.AddRange(Models);
        return clone;
    }
}
