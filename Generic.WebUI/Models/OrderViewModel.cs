using System.Collections.Generic;
using Generic.Entities;

namespace Generic.WebUI.Models
{
    public class OrderViewModel
    {
        public List<Orders> Orders { get; set; }
        public PagingInfo PagingInfo { get; set; }
        
      
    }
}