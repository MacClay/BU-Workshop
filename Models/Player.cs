using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetRPG.Models
{
    public record Player
    {
        public Guid id { get; init; }
        public string Name { get; init; }
        public decimal Balance { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }

}