using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTools.Common
{
    public class BaseAssetFileParser : IAssetFileParser
    {
        private readonly String m_FileName;

        public BaseAssetFileParser(String file)
        {
            m_FileName = file;
        }

        public event AssetPriceReadyHandler AssetPriceReady;

        public void parse()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(m_FileName))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        ParseLine(line);
                    }
                }
            } catch(Exception ex)
            {
            }

            FireEndOfPrice();
        }

        protected virtual void ParseLine(String line) { }
        protected void FireAssetPriceReady(String id, String price)
        {
            AssetPriceReady?.Invoke(id, price);
        }


        public event EndOfParseHandler EndOfParse;
        protected void FireEndOfPrice() { EndOfParse?.Invoke(); }

    }
}
