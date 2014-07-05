using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CmsMaster.Models
{
    public enum ContentType : byte
    {
        About = 1,
        Contact = 2,
        Partnership = 3
    }

    public enum CooperationType : byte
    {
        [Description("Lekarze")]
        Doctors = 1,

        [Description("Prawnicy")]
        Lawyers = 2,

        [Description("Inne")]
        Others = 3
    }
}