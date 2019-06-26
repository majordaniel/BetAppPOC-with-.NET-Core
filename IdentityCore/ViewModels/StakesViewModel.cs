using IdentityCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityCore.ViewModels
{
    public class StakesViewModel
    {
        public TbStakes Stakes { get; set; }
        public List<TbStakeDetails> StakesDetails { get; set; }
    }
}
