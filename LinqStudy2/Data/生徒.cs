using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqStudy2.Data
{
    class 生徒
    {
        public string クラス { get; set; }

        public string 姓 { get; set; }

        public string セイ { get; set; }

        public string 名 { get; set; }

        public string メイ { get; set; }

        public string 性別 { get; set; }

        public List<試験結果> 成績 { get; set; }
    }
}
