using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SearchBarTest
{
    internal class TestViewModel
    {
        private bool isInitialized;

        public Command TestCommand { get; }

        public TestViewModel()
        {
            Task.Run(() =>
            {
                Thread.Sleep(5000);

                isInitialized = true;

                Debug.WriteLine($">>> Initialized: {isInitialized}");

                TestCommand.ChangeCanExecute();
            });

            TestCommand = new Command(() =>
            {
                Debug.WriteLine(">>> Command invoked.");
            }, () => isInitialized);
        }
    }
}
