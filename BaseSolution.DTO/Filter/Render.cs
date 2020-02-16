using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.DTO.Filter
{
    public class Render
    {
        public RenderType RenderType { get; set; }
        public Restriction Restriction { get; set; }
        public string HtmlContent { get; set; }

    }
}
