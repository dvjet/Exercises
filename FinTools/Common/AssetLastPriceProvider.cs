using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTools.Common
{
    public class AssetLastPriceProvider : IAssetPriceProvider
    {
        String m_AssetId;
        String m_LastPrice;

        public event AssetPriceReadyHandler AssetPriceReady;

        public void OnAssetPriceReady(string id, string price)
        {
            if (m_AssetId != null && m_AssetId != id)
                AssetPriceReady?.Invoke(m_AssetId, m_LastPrice);

            m_AssetId = id;
            m_LastPrice = price;
        }

        public void OnEndOfParse() {
            AssetPriceReady?.Invoke(m_AssetId, m_LastPrice);
            FireEndOfPrice();
        }

        public event EndOfParseHandler EndOfParse;
        protected void FireEndOfPrice() { EndOfParse?.Invoke(); }

    }
}
