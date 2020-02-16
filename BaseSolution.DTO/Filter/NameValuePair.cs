using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.DTO.Filter
{
    public class NameValuePair
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public Render Render { get; set; }
        public bool IsMultiple { get; set; }

        public NameValuePair()
        {
            Render = new Render();
        }
    }
    public enum RenderType
    {
        Text,
        Select,
        Checkbox,
        Range,
    }
    public enum Restriction
    {
        Money,
        Date,
        StringLenght,
    }
}
