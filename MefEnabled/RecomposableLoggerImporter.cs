using System.ComponentModel.Composition;
using MefEnabled.Interfaces;

namespace MefEnabled
{
    [Export(typeof(Recomposable<ILogger>))]
    public class RecomposableLoggerImporter : Recomposable<ILogger> { }
}