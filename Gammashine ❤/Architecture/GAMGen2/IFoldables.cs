using System;
using System.Globalization;

namespace Snaplight
{
    public interface IGlobalizable<T> where T : struct, IConvertible
    {
        public T GlobalizationVariable { get; set; }
    }

    public interface IVariable<K>
        where K : struct, IConvertible
    {
        public T Variability<T>(T value, IGlobalizable<K> glo) 
            where T : struct, IConvertible;
    }

    public interface IFoldables : IGlobalizable<float>
    {

    }

    public interface IBindable<T, K, JReturn>
        where T : IFoldables
        where K : IFoldables
    {
        public JReturn BindData(T l, K r);
    }

    public interface ISuperFoldables : IFoldables, IVariable<float>
    {
        T IVariable<float>.Variability<T>(T value, IGlobalizable<float> glo) where T : struct
            => (T)Convert.ChangeType(value.ToSingle(CultureInfo.CurrentCulture) * glo.GlobalizationVariable, typeof(T));
    }
}
