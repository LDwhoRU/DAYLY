using System;
using System.Collections.Generic;
using System.Text;

using DAYLY;
using DAYLY.Models;
using SQLite;
using Xamarin.Forms;

namespace DAYLY.ViewModels
{
    public class NewEventViewModel
    {
        public SQLiteConnection conn;
        public NewEventViewModel()
        {
            conn = DependencyService.Get<Isqlite>().GetConnection();
            try
            {
                conn.DropTable<Event>();
                conn.DropTable<Note>();
                conn.DropTable<Programme>();
            }
            catch (Exception e)
            {
                throw e;
            }
            conn.CreateTable<Note>();
            conn.CreateTable<Programme>();
            conn.CreateTable<Event>();
        }
        public void SaveCalendar(string CalendarName, string Colour)
        {
            int isSuccess;
            // Add Programme
            string hexCode;
            switch (Colour)
            {
                case "Green":
                    hexCode = "#99ff33";
                    break;
                case "Blue":
                    hexCode = "#0099ff";
                    break;
                case "Red":
                    hexCode = "#ff5050";
                    break;
                case "Orange":
                    hexCode = "#ff9966";
                    break;
                case "Yellow":
                    hexCode = "#ffff99";
                    break;
                case "Purple":
                    hexCode = "#993399";
                    break;
                default:
                    hexCode = "#ffffff";
                    break;
            }
            Programme newProgramme = new Programme
            {
                Name = CalendarName,
                HexColour = hexCode
            };
            isSuccess = 0;
            try
            {
                isSuccess = conn.Insert(newProgramme);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
