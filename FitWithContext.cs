using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fit
{
    internal class FitEntities: ModelFit3
    {
        private static ModelFit3 _context;

        public static ModelFit3 GetContext()
        {
            if (_context == null)
                _context = new ModelFit3();
            return _context;
        }
    }
}
