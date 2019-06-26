﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityCore.Models
{
    public class TbOdds
    {

        [Key]
        public int OddId { get; set; }
        public string GameName { get; set; }
        public int HomeValue { get; set; }
        public int DrawValue { get; set; }
        public int AwayValue { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime GameDate { get; set; }

        public long StakeAmount { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public bool Status { get; set; }


        public string OddCreator { get; set; }


    }
}
