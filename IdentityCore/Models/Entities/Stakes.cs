using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityCore.Models.Entities
{
    public class Stakes
    {
        public TbStakes Stake { get; set; }
        public List<TbStakeDetails> StakesDetails { get; set; }
    }
}
