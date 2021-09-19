using DemoContactAPI.Businesses;
using DemoContactAPI.Classes;
using DemoContactAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        [HttpGet]
        public object Get()
        {
            var response = ContactBO.Docfile();
            //var data = FechDataClass.GetData();
            return JsonResultCommon.ThanhCong(response);
        }
        [HttpPost]
        public object PostData([FromBody] ContactModel contact)
        {
            try
            {
                if(ContactBO.RequestIP(contact.ip) >= 5)
                {
                    string err = "Bạn đã gửi quá số lượng cho phép";
                    return JsonResultCommon.ThatBai(err);
                }
                
                if(!ContactBO.IsValidPhone(contact.phone))
                {
                    string err = "Số điện thoại không hợp lệ";
                    return JsonResultCommon.ThatBai(err);
                }


                contact.createddate = DateTime.Now.ToString();
                // var data = FechDataClass.PostData(contact); 
                var x = ContactBO.Ghifile(JsonConvert.SerializeObject(contact));
                return JsonResultCommon.ThanhCong(contact);
            }
            catch(Exception e)
            {
                return JsonResultCommon.ThatBai(e.Message);
            }
        }

    }
}
