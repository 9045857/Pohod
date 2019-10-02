using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostSharing
{
       public class GeneralInfo
    {
        /// <summary>
        /// Коэффициент участия в платеже (вес участия) конкретного товара.
        /// Если человек вносит не долю от общей суммы, а какую-нибудь определенную сумму,
        /// то коэффициент -1.
        /// </summary>
        public const int PersonalDebtFactor = -1;
        public const int StandartDebtFactor = 1;
    }
}
