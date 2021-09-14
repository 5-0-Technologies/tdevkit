using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SDK.Filters.Input
{
    public class TcpListenerFilter : InputChannelFilter<byte>
    {
        private readonly TcpListener tcpListener;
        private readonly int bufferSize;

        public TcpListenerFilter(ChannelWriter<byte> channelWriter, TcpListener tcpListener, int bufferSize = 256) : base(channelWriter)
        {
            this.tcpListener = tcpListener ?? throw new ArgumentNullException(nameof(tcpListener));
            this.bufferSize = bufferSize;
        }

        public override async Task Loop()
        {
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            await Task.Run(async () =>
            {
                NetworkStream stream = tcpClient.GetStream();
                byte[] buffer = new byte[bufferSize];
                int size = 0;
                while ((size = stream.Read(buffer, 0, 1)) != 0)
                {
                    await Writer.WriteAsync(buffer[0], cancellationTokenSource.Token);
                }
                tcpClient.Close();
            }, cancellationTokenSource.Token).ConfigureAwait(false);
        }

        protected internal override void BeforeRun()
        {
            tcpListener.Start();
        }

        protected internal override void AfterRun()
        {
            tcpListener.Stop();
        }
    }
}
