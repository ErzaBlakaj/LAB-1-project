using lab1_project.Models;
using lab1_project.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace lab1_project.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class NjoftimetController
    {
        private NjoftimetService _NjoftimetService;
        private NjoftimetService _njoftimetService;
        private readonly object njoftimetId;

        public NjoftimetController(IConfiguration configuration)
        {
            string connectionString = configuration.GetValue<string>("ConnectionString");

            _njoftimetService = new NjoftimetService(connectionString);
        }


        [HttpPost("insertNjoftimet")]
        public string InsertNjoftimetEndPoint([FromBody] Njoftimet njoftimet)
        {
          
            try
            {
                _njoftimetService.InsertNjoftimet(njoftimet.Titulli, njoftimet.Pershkrimi, njoftimet.Id_Linjat);

                return "Njoftimi u  krijua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpDelete("deleteNjoftimetById")]
        public string DeleteNjoftimetById([FromQuery] int njoftimetkId)
        {
            try
            {
                _njoftimetService.DeleteNjoftimetById(njoftimetId);

                return "Njoftimi u fshi  me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpGet("getAllNjoftimet")]
        public List<GetNjoftimet> GetAllNjoftimet()
        {
            try
            {

                return _njoftimetService.GetNjoftimet();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("updateNjoftimetById")]
        public string UpdateNjoftimetById([FromBody] Njoftimet njoftimet)
        {
            try
            {
                _njoftimetService.InsertNjoftimet(njoftimet.Titulli, njoftimet.Pershkrimi, njoftimet.Id_Linjat);

                return "Feedback u perditesua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
