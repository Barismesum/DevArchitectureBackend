using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class Product:BaseEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductColor { get; set; }
        public string ProductSize { get; set; }
    }
}
