using System;
using System.Collections;

namespace DesktopClockTests.FakeClasses
{
    public interface INotifyFakeMethodCalled
    {
        public event FakeMethodCalledEventHandler FakeMethodCalled;
    }

    public class FakeMethodCalledEventArgs : EventArgs
    {
        public string MethodName { get; private set; }
        public IList MethodArgs { get; private set; }

        public FakeMethodCalledEventArgs(string medthodName, IList methodArgs)
        {
            MethodName = medthodName;
            MethodArgs = methodArgs;
        }
    }

    public delegate void FakeMethodCalledEventHandler(object sender, FakeMethodCalledEventArgs e);
}
