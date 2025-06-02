using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_op.Models
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }

        protected BaseEntity(int id)
        {
            ID = id;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"ID: {ID}");
        }
    }
}
