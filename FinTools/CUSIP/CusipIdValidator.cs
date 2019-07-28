using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinTools.CUSIP
{
    public class CusipIdValidator : IAssetIdValidator
    {
        private readonly Regex m_CUSIP = new Regex(@"[0-9]{3}[a-zA-Z0-9]{5}", RegexOptions.IgnoreCase);

        public bool isAssetId(string id)
        {
            return m_CUSIP.IsMatch(id);
        }
    }
}
