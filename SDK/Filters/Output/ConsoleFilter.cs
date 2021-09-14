using System;
using System.Threading.Channels;

namespace SDK.Filters.Output
{
    public class ConsoleFilter<TRead> : OutputChannelFilter<TRead>
    {
        private readonly Action<TRead> action;

        public ConsoleFilter(ChannelReader<TRead> channelReader) : this(channelReader, data => Console.WriteLine(data))
        {

        }

        public ConsoleFilter(ChannelReader<TRead> channelReader, Action<TRead> action) : base(channelReader)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        protected override void ProcessData(TRead read)
        {
            action(read);
        }

        protected internal override void AfterRun()
        {
        }

        protected internal override void BeforeRun()
        {
        }
    }
}
