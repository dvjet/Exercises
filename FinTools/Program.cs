using FinTools.Common;
using FinTools.CUSIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTools
{
    class Program
    {
        static void Main(string[] args)
        {
            IAssetFileParser parser = new AssetFileParser<CusipIdValidator>("C:\\Dev\\CS\\FinTools\\CUSIP_All.txt");
            IAssetPriceProvider pricer = new AssetLastPriceProvider();
            IAssetPriceWriter writer = new AssetFileWriter("C:\\Dev\\CS\\FinTools\\CUSIP_LastPrice.txt");

            parser.AssetPriceReady += pricer.OnAssetPriceReady;
            pricer.AssetPriceReady += writer.OnAssetPriceReady;

            parser.EndOfParse += pricer.OnEndOfParse;
            pricer.EndOfParse += writer.OnEndOfParse;
            
            parser.parse();
        }
    }
}
