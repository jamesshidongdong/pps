using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysPPS.Library
{
   public sealed class UnityIOC
    {
       public class UOF
       {
           public const string AlwaysPPS = "AlwaysPPSUnitOfWork";
           public const string AlwaysHR = "AlwaysHRUnitOfWork";    
       }
       public class Context
       {
           public const string AlwaysPPS = "AlwaysPPSDataEntryDbContext";
           public const string AlwaysHR = "AlwaysHRDataEntryDbContext";
       }
    }
}
