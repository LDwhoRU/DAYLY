using System;

namespace DAYLY
{
    public class Default
    {
        public string AppThemeStr { get; set; }
        public string AppThemePos { get; set; }

        public void SetDefaults()
        {
            AppThemeStr = "Follow system";
            AppThemePos = "0";
        }
    }
}
