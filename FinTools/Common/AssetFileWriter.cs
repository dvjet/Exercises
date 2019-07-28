using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTools.Common
{
    public class AssetFileWriter : IAssetPriceWriter
    {
        private String m_FileName;
        private StreamWriter m_Writer;

        public AssetFileWriter(String file) { m_FileName = file; }

        public void OnAssetPriceReady(string id, string price)
        {
            if (m_Writer == null)
                m_Writer = new StreamWriter(m_FileName);

            m_Writer.WriteLine(id + " " + price);
        }

        public void OnEndOfParse()
        {
            m_Writer?.Close();
        }
    }
}
