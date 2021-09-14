using System;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SDK.Filters.Input
{
    public class InputChannelFilter<TWrite> : ChannelFilter<TWrite, TWrite>
    {
        public InputChannelFilter() { }

        public InputChannelFilter(ChannelWriter<TWrite> channelWriter) : base()
        {
            Writer = channelWriter ?? throw new ArgumentNullException(nameof(channelWriter));
        }

        public override async Task Loop()
        {
        }

        protected internal override void AfterRun()
        {
        }

        protected internal override void BeforeRun()
        {
        }
    }
}
