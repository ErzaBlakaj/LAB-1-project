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
    public class FeedbackController
    {
        private FeedbackService _feedbackService;

        public FeedbackController(IConfiguration configuration)
        {
            string connectionString = configuration.GetValue<string>("ConnectionString");

            _feedbackService = new FeedbackService(connectionString);
        }

        [HttpPost("insertFeedback")]
        public string InsertFeedbackEndPoint([FromBody] Feedback feedback)
        {
            try
            {
                _feedbackService.InsertFeedback(feedback.Emri_Perdoruesit, feedback.Komenti, feedback.Vleresimi, feedback.Id_Linjat);

                return "Feedbacku u  krijua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpDelete("deleteFeedbackById")]
        public string DeleteFeedbackById([FromQuery] int feedbackId)
        {
            try
            {
                _feedbackService.DeleteFeedbackById(feedbackId);

                return "Feedback u fshi  me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpGet("getAllFeebacks")]
        public List<GetFeedbacks> GetAllFeedbacks()
        {
            try
            {

                return _feedbackService.GetFeedbacks();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("updateFeedbackById")]
        public string UpdateFeedbackById([FromBody] Feedback feedback)
        {
            try
            {
                _feedbackService.UpdateFeedbackById(feedback.Emri_Perdoruesit, feedback.Komenti, feedback.Vleresimi, feedback.Id_Linjat);

                return "Feedback u perditesua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
