using System;
using System.Collections.Generic;
using System.Text;

namespace DAYLY.ViewModels
{
    public class ProgrammeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HexColour { get; set; }
        public string BorderColour { get; set; }
        public ProgrammeViewModel(int inputId, string inputName, string inputHexColour, string inputBorderColour)
        {
            Id = inputId;
            Name = inputName;
            HexColour = inputHexColour;
            BorderColour = inputBorderColour;
        }
    }
}
