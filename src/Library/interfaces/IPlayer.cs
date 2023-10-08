using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public interface IPlayer
    {
        string Id {get; set;}

        void SetId (string id);
    }
}