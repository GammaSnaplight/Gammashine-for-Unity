namespace Snaplight
{
    public interface IBehavioral
    {

    }

    public interface IInput : IBehavioral
    {
        public void InputUpdate();
    }

    public interface IControl : IBehavioral
    {
        public void ControlUpdate();
    }

    public interface IUnder : IBehavioral
    {
        public void UnderUpdate();
    }

    public interface IUnderFixed : IBehavioral
    {
        public void UnderFixedUpdate();
    }
}
