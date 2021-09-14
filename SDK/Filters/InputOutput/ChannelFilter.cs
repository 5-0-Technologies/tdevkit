using System.Threading.Channels;

namespace SDK.Filters
{
    public abstract class ChannelFilter<TRead, TWrite> : Filter
    {
        public ChannelReader<TRead> Reader {  set; get; }
        public ChannelWriter<TWrite> Writer { set; get; }
    }
}
