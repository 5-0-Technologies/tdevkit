using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SDK.Filters.Input
{
    public class UdpListenerFilter : InputChannelFilter<byte[]>
    {
        protected readonly UdpClient udpClient;

        public UdpListenerFilter(ChannelWriter<byte[]> channelWriter, UdpClient udpClient) : base(channelWriter)
        {
            this.udpClient = udpClient ?? throw new ArgumentNullException(nameof(udpClient));
        }

        public override async Task Loop()
        {
            UdpReceiveResult udpReceiveResult = await udpClient.ReceiveAsync();
            await Writer.WriteAsync(udpReceiveResult.Buffer);
        }
    }
}
