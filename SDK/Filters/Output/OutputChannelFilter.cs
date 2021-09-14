using System;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SDK.Filters.Output
{
    public abstract class OutputChannelFilter<TRead> : ChannelFilter<TRead, TRead>
    {
        public OutputChannelFilter(ChannelReader<TRead> channelReader)
        {
            Reader = channelReader ?? throw new ArgumentNullException(nameof(channelReader));
        }

        public override async Task Loop()
        {
            if(await Reader.WaitToReadAsync())
            {
                var data = await Reader.ReadAsync();
                ProcessData(data);
            }
        }

        protected abstract void ProcessData(TRead read);
    }
}
