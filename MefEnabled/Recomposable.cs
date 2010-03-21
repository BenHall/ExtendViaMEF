using System.ComponentModel.Composition;

namespace MefEnabled
{
    [Export]
    public class Recomposable<T>
    {
        [Import(AllowRecomposition = true)]
        public T Value { get; private set; }
    }
}