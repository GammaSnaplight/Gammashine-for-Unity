namespace Snaplight.Gen3
{
    public interface IMultipurposeModulable<T> : IRegularModulable
        where T : IFoldables<T>
    {
        public T Multipurpose { get; set; }
    }
}
