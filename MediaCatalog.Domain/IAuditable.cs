using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalog.Domain
{
    public interface IAuditable
    {
        int Id { get; set; }
        DateTime? DateCreated { get; set; }
        DateTime? DateModified { get; set; }

        string CreatedUser { get; set; }
        string ModifiedUser { get; set; }
    }
}
