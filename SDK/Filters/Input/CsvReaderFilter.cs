using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SDK.Filters.Input
{
    public class CsvReaderFilter : InputChannelFilter<Row>
    {
        private readonly string path;
        private TextFieldParser parser;
        public string[] Delimiter { get; set; } = new string[] { "," };
        public FieldType TextFieldType { get; set; } = FieldType.Delimited;

        public CsvReaderFilter(ChannelWriter<Row> channelWriter, string path) : base(channelWriter)
        {
            this.path = path;
        }

        public override async Task Loop()
        {
            try
            {
                if (!parser.EndOfData)
                {
                    await Writer.WriteAsync(new Row()
                    {
                        Index = parser.LineNumber,
                        Fields = parser.ReadFields(),
                        HasFieldsEnclosedInQuotes = parser.HasFieldsEnclosedInQuotes,
                    }, cancellationTokenSource.Token);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "");
            }
        }

        protected internal override void BeforeRun()
        {
            if (!ValidatePath())
            {
                throw new FileNotFoundException();
            }

            parser = new TextFieldParser(path);
            parser.TextFieldType = TextFieldType;
            parser.SetDelimiters(Delimiter);
        }

        protected internal override void AfterRun()
        {
            parser.Close();
        }

        public bool ValidatePath()
        {
            return File.Exists(path);
        }
    }

    public class Row
    {
        public long Index { get; set; }
        public string[] Fields { get; set; }
        public bool HasFieldsEnclosedInQuotes { get; set; }
    }
}
