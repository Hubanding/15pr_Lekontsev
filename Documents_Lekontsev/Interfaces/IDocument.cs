using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documents_Lekontsev.Interfaces
{
    public interface IDocument
    {
        void Save(bool Update = false);

        List<Documents_Lekontsev.Classes.DocumentContext> AllDocuments(System.Data.OleDb.OleDbDataReader oleDbDataReader);

        void Delete();
    }
}
