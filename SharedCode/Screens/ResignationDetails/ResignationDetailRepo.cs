using Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedCode
{
    public class ResignationDetailRepo
    {
        ResignationRepo resignationRepo;
        ResignationDetailModelConversion resignationDetailModelConversion;

        public string Message { get; set; }

        public ResignationDetailRepo()
        {
            resignationRepo = new ResignationRepo();
            resignationDetailModelConversion = new ResignationDetailModelConversion();
        }

        ///<summary>
        ///Insert Resignation Detail in Database
        ///</summary>
        ///<param name="content"></param>
        ///<returns></returns>
        public bool InsertResignationDetail(string content)
        {
            var resignation = JsonConvert.DeserializeObject<ResignationDetail>(content);
            var result = resignationRepo.InsertOrUpdate(resignation.detailTable);
            if (result)
            {
                Message = "";
                return true;
            }
            else
            {
                Message = resignationRepo.Message;
                return false;
            }
        }

        ///<summary>
        ///Get User Data From Database
        ///</summary>
        ///<param name="id"></param>
        ///<returns></returns>
        public ResignationDetailTable GetUser(int id)
        {
            return resignationRepo.GetUser(id);
        }
    }
}
