using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DAYLY
{
    public interface Isqlite
    {
        SQLiteConnection GetConnection();
    }
}
