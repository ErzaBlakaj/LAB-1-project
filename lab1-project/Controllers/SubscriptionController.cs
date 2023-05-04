using lab1_project.Models;
using lab1_project.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace lab1_project.Controllers
{
    public class SubscriptionController
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


        }
    }
}


