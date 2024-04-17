using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fit
{
    internal class FitEntities: fit3Entities
    {
        private static fit3Entities _context;

        public static fit3Entities GetContext()
        {
            if (_context == null)
                _context = new fit3Entities();
            return _context;
        }
    }
}
