using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace SDK.Filters.InputOutput
{
    public class TimerFilter : Filter
    {
        private readonly SemaphoreSlim methodLock;
        private readonly System.Timers.Timer timer;
        private readonly Filter filter;

        public TimerFilter(Filter filter, double intervalMS, int semaphoreInitialCount, int semaphoreMaxCount)
        {
            this.filter = filter ?? throw new ArgumentNullException(nameof(filter));
            methodLock = new SemaphoreSlim(semaphoreInitialCount, semaphoreMaxCount);
            timer = new System.Timers.Timer(intervalMS);
            timer.Elapsed += OnTimedEvent;
        }

        private async void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (methodLock.CurrentCount == 0)
            {
                return;
            }

            await methodLock.WaitAsync();
            try
            {
                await Loop();
            }
            finally
            {
                methodLock.Release();
            }
        }

        public override async Task Loop()
        {
            await filter.Loop();
        }

        protected override Task Run()
        {
            return Task.CompletedTask;
        }

        protected internal override void BeforeRun()
        {
            filter.BeforeRun();
            timer.Start();
        }

        protected internal override void AfterRun()
        {
            timer.Stop();
            filter.AfterRun();
        }
    }
}
