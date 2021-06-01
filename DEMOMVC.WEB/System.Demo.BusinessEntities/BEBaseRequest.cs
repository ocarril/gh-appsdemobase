using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Demo.BusinessEntities
{

    public class BEBuscadorBaseRequest : BEBuscadorBase
    {
        public BEBuscadorBaseRequest()
        {
            jqPageSize = 10;
            jqCurrentPage = 1;
            jqSortOrder = "ASC";
        }

        public int jqPageSize { get; set; }

        public int jqCurrentPage { get; set; }

        public string jqSortColumn { get; set; }

        public string jqSortOrder { get; set; }


    }

    public class BEGetRequest
    {
        public BEGetRequest()
        {
            GetUser = string.Empty;
        }


        [JsonIgnore]
        public int codEmpresa { get; set; }

        [JsonIgnore]
        public string GetUser { get; set; }

        [JsonIgnore]
        public int IdRecord { get; set; }

        [JsonIgnore]
        public string IdRecordStr { get; set; }
    }


}
