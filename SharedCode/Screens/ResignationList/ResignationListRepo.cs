using Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedCode
{
    public class ResignationListRepo
    {
        ResignationRepo detailRepo;
        Resignation resignation;
        ResignationDetailModelConversion detailModelConversion;

        public string Message { get; set; }
        public ResignationListRepo()
        {
            detailRepo = new ResignationRepo();
            resignation = new Resignation();
            detailModelConversion = new ResignationDetailModelConversion();
        }

        /// <summary>
        /// Gets Data From DataBase 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public bool GetAllData(string content)
        {
            bool isShowData = false;

            resignation = JsonConvert.DeserializeObject<Resignation>(content);

            if(resignation != null)
            {
                foreach (var item in resignation.ResignationModelList)
                {
                    var model = detailModelConversion.ToResignationTable(item);
                    isShowData = detailRepo.InsertOrUpdate(model);

                    if (!isShowData)
                    {
                        if (isShowData)
                        {
                            Message = "";
                            return true;
                        }
                        Message = detailRepo.Message;
                        return false;
                    }
                    return false;
                }
            }
            return false;
        }
    }
}
