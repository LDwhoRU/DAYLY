using System;
using System.Collections.Generic;
using System.Text;

using DAYLY;
using DAYLY.Models;
using SQLite;

namespace DAYLY.ViewModels
{
    class NewEventViewModel
    {
        private void Signed_Clicked(object sender, EventArgs e, SQLiteConnection conn)
        {
            TestEvent test = new TestEvent();
            test.FirstEntry = FirstEntry.Text;
            int x = 0;
            try
            {
                x = conn.Insert(test);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
