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
    public class SubscriptionController
    {
        
        private SubscriptionService _subscriptionService;

        public SubscriptionController(IConfiguration configuration)
        {
            string connectionString = configuration.GetValue<string>("ConnectionString");

            _subscriptionService = new SubscriptionService(connectionString);
        }


        [HttpPost("insertSubscription")]
        public string InsertSubscriptionEndPoint([FromBody] InsertSubscriptionModel subscription)
        {

            try
            {
                _subscriptionService.InsertSubscription(subscription.Duration, subscription.Price,subscription.Start_Date,subscription.End_Date);

                return "Subscription u  krijua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpDelete("deleteSubscription")]
        public string DeleteSubscription([FromQuery] int subscriptionId)
        {
            try
            {

                _subscriptionService.DeleteSubscription(subscriptionId);

                return "Subscription u fshi  me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpGet("getAllSubscriptions")]
        public List<GetSubscription> GetAllSubscriptions()
        {
            try
            {

                return _subscriptionService.GetSubscription();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("updateSubscriptionById")]
        public string UpdateSubscriptionById([FromBody] InsertSubscriptionModel  subscription)
        {
            try
            {
                _subscriptionService.UpdateSubscription(subscription.Duration, subscription.Price);

                return "Subscription u perditesua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }

}


