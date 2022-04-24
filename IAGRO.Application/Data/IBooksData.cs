using IAGRO.Domain.Entities;
using System.Collections.Generic;

namespace IAGRO.Application.Data
{
    public interface IBooksData
    {
        IList<Books> GetData();
    }
}
