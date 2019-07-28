using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTools
{
    public interface IAssetPriceProvider
    {
        void OnAssetPriceReady(String id, String price);
        void OnEndOfParse();
        event AssetPriceReadyHandler AssetPriceReady;
        event EndOfParseHandler EndOfParse;
    }
}
