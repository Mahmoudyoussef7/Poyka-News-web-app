using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace News_Project.Models
{
    public class News
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public string Topic { get; set; }
        public int Cat_Id { get; set; }

        [ForeignKey("Cat_Id")]
        public virtual Category Category { get; set; }

    }
}
