
using Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedCode
{
    public class ResignationDetailModelConversion
    {
        ///<summary>
        ///Conerts Resignation Detail Model to Resignation Detail Table
        ///</summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResignationDetailTable ToResignationTable(ResignationDetailModel model)
        {
            var content = JsonConvert.SerializeObject(model);
            return JsonConvert.DeserializeObject<ResignationDetailTable>(content);
        }

        public List<ResignationDetailModel> ToResignationModelList(List<ResignationDetailTable> resignationTable)
        {
            var content = JsonConvert.SerializeObject(resignationTable);
            return JsonConvert.DeserializeObject<List<ResignationDetailModel>>(content);
        }
    }
}
