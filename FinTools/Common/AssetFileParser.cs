using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTools.Common
{
    public class AssetFileParser<T> : BaseAssetFileParser where T : IAssetIdValidator, new()
    {
        private T m_AssetIdValidator = new T();
        private String m_AssetId;
        private String m_AssetPrice;

        public AssetFileParser(String file) : base(file) { }

        protected override void ParseLine(string line)
        {
            if (m_AssetIdValidator.isAssetId(line))
            {
                m_AssetId = line;
                m_AssetPrice = null;
            }
            else
                m_AssetPrice = line;

            if (m_AssetId != null && m_AssetPrice != null)
                FireAssetPriceReady(m_AssetId, m_AssetPrice);
        }
    }
}
