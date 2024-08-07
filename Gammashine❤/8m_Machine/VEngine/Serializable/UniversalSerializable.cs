//using System;
//using System.IO;
//using System;
//using UnityEngine;
//using System.Runtime.Serialization.Formatters.Binary;

//[Serializable]
//public class UniversalSerializable<T> : ISerializationCallbackReceiver
//{
//    [SerializeField, HideInInspector]
//    private string _assemblyQualifiedName;

//    [SerializeField]
//    private string _xml;

//    private T _variable;

//    public T Variable
//    {
//        get => _variable;
//        set => _variable = value;
//    }

//    public void OnBeforeSerialize()
//    {
//        if (_variable == null)
//        {
//            _assemblyQualifiedName = null;
//            _xml = null;
//            return;
//        }

//        _assemblyQualifiedName = _variable.GetType().AssemblyQualifiedName;
//        _xml = SerializeToXml(_variable);
//    }

//    public void OnAfterDeserialize()
//    {
//        if (string.IsNullOrEmpty(_assemblyQualifiedName) || string.IsNullOrEmpty(_xml))
//        {
//            _variable = default;
//            return;
//        }

//        Type interfaceType = Type.GetType(_assemblyQualifiedName);

//        _variable = (T)DeserializeFromXml(interfaceType, _xml);
//    }

//    private string SerializeToXml(T data)
//    {
//        if (data == null)
//            return null;

//        XmlSerializer serializer = new(data.GetType());
//        using (StringWriter writer = new())
//        {
//            serializer.Serialize(writer, data);
//            return writer.ToString();
//        }
//    }

//    private object DeserializeFromXml(Type type, string data)
//    {
//        if (string.IsNullOrEmpty(data))
//            return null;

//        XmlSerializer serializer = new(Type.GetType(_assemblyQualifiedName));
//        using (StringReader reader = new(data))
//        {
//            return serializer.Deserialize(reader);
//        }
//    }
//}
