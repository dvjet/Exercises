using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTools
{
    public delegate void AssetPriceReadyHandler(String id, String price);
    public delegate void EndOfParseHandler();
    
    public interface IAssetFileParser
    {
        void parse();
        event AssetPriceReadyHandler AssetPriceReady;
        event EndOfParseHandler EndOfParse;
    }
}
