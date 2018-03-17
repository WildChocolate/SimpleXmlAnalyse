using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ConsolFolder
{

    public class Note
    {
        public string Description { get; set; }

        public string IsCustomDescription { get; set; }

        public string NoteText { get; set; }

        public NoteContext NoteContext { get; set; }

        public Visibility Visibility { get; set; }

    }
}
