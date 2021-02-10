using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace PersonalSite.UI.MVC.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "* Please provide a Name* ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Please provide a Email *")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required(ErrorMessage = "* Please provide a Message *")]
        [UIHint("MultilineText")]
        public string Message { get; set; }

    }
}