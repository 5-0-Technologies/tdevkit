using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SDK.Filters
{
    public interface IFilter { }

    public abstract class Filter
    {
        protected readonly ILogger logger = new LoggerFactory().CreateLogger("Filter");

        protected readonly object obj = new object();

        protected CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        protected volatile bool isRunning = false;

        protected internal abstract void BeforeRun();
        protected internal abstract void AfterRun();

        public abstract Task Loop();

        protected virtual async Task Run()
        {
            while (isRunning && !cancellationTokenSource.Token.IsCancellationRequested)
            {
                await Loop();
            }
        }

        public virtual void Start()
        {
            try
            {
                lock (obj)
                {
                    if (isRunning)
                    {
                        return;
                    }

                    isRunning = true;
                    cancellationTokenSource = new CancellationTokenSource();

                    BeforeRun();
                    Task.Run(async () =>
                    {
                        await Run();
                    }, cancellationTokenSource.Token);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "");
                throw;
            }
        }

        public virtual void Stop()
        {
            try
            {
                lock (obj)
                {
                    if (!isRunning)
                    {
                        return;
                    }

                    isRunning = false;
                    cancellationTokenSource.Cancel();
                    AfterRun();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "");
                throw;
            }
        }
    }
}
