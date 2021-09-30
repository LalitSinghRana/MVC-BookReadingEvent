using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public class NagarroBookEventValidationResult
    {
        public IList<NagarroBookEventValidationFailure> Errors { get; private set; }

        public bool IsValid
        {
            get { return Errors == null || Errors.Count == 0; }
        }

        public NagarroBookEventValidationResult(IList<NagarroBookEventValidationFailure> failures)
        {
            Errors = failures;
        }

        public NagarroBookEventValidationResult()
        {
            Errors = new List<NagarroBookEventValidationFailure>();
        }
    }
}
