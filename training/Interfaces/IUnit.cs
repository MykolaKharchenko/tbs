﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using training.Models.Units;
using training.Models;

namespace training.Interfaces
{    
    public interface IUnit
    {
        int UnitSize { get; }
        bool IsAlive { get; }
        bool IsActive { get; }

        string passiveUnitImagePath { get; set; }
        string activeUnitImagePath { get; set; }

        void GetDamage(Unit enemy = null);
        void Move(Battlefield bf = null);
        void SpecialSkill(Unit targetUnitStack = null, Battlefield bf = null);
    }
}
