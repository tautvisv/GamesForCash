using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UnitOfWorkExample.Domain.Entities;

namespace UnitOfWorkExample.Web.Models.Home
{
    public class IndexViewModel
    {
        public IndexViewModel(bool isAuth, string name)
        {
            IsAuthenticated = isAuth;
            Name = name;
        }
        public IList<Product> Products { get; set; }

        [Required]
        public string ProductName { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Name { get; set; }
    }
}