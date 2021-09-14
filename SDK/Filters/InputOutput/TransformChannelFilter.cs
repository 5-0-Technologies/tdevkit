using System;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SDK.Filters.InputOutput
{
    public class TransformChannelFilter<TRead, TWrite> : ChannelFilter<TRead, TWrite>
    {
        protected Func<TRead, TWrite> transform;

        public TransformChannelFilter(Func<TRead, TWrite> transform)
        {
            this.transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        public TransformChannelFilter(ChannelReader<TRead> reader, ChannelWriter<TWrite> writer, Func<TRead, TWrite> transform)
        {
            Writer = writer ?? throw new ArgumentNullException(nameof(writer));
            Reader = reader ?? throw new ArgumentNullException(nameof(reader));
            this.transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        public override async Task Loop()
        {
            while(await Reader.WaitToReadAsync())
            {
                var read = await Reader.ReadAsync();
                var write = transform(read);
                await Writer.WriteAsync(write);
            }
        }

        protected internal override void AfterRun()
        {
        }

        protected internal override void BeforeRun()
        {
        }
    }
}
