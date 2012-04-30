using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace KnockoutTutorials.Models
{
    [Serializable]
    public class Task
    {
        public string title { get; set; }
        public bool isDone { get; set; }
        public bool _destroy { get; set; }
    }
}
