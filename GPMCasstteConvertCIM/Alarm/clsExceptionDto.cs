using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Alarm
{
    public class clsExceptionDto
    {
        [PrimaryKey]
        public DateTime Time { get; set; }
        public string ErrorMessage { get; set; } = "";

        public string ClassName { get; set; } = "";
        public int LineNumber { get; set; } = -1;
        public bool IsChecked { get; set; } = false;
    }
}
