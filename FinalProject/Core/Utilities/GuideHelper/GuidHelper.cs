using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.GuideHelper
{
    public class GuidHelper
    {
        public static string CreateGuide()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
