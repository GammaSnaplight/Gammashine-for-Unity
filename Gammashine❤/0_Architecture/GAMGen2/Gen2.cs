using Snaplight.Controllable;

namespace Snaplight.Gen2
{
    public interface IUndertaking
    {
        public Selector Undertaking { get; set; }
    }

    public interface ILiabilities
    {
        public ModuleLiabilities Liabilities { get; set; }
    }
}
