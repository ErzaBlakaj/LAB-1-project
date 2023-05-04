using Microsoft.VisualBasic;
using System;

namespace lab1_project.Models
{
    public class InsertSubscriptionModel
    {
        public int Price { get; set; }
        public string Duration { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
    }
}
