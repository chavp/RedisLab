using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisModels
{
    public class Word
    {
        protected Word() { }
        public Word(long id)
        {
            Id = id;
        }

        public long Id { get; protected set; }
        public string Value { get; set; }
    }
}
