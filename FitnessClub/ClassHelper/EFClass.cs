using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FitnessClub.DB;
using FitnessClub.Windows;

namespace FitnessClub.ClassHelper
{
    public class EFClass
    {
       public static Entities context { get; set; } = new Entities();
    }
}
