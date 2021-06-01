using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Demo.Tools.entities
{

    public class OperationResult
    {
        public OperationResult()
        {
            data = string.Empty;
            brokenRulesCollection = new List<BrokenRule>();
        }

        public List<BrokenRule> brokenRulesCollection { get; set; }

        public string data { get; set; }

        public bool isValid { get; set; }
    }


    public class BrokenRule
    {
        public BrokenRule()
        {
        }


        public string description { get; set; }


        public string property { get; set; }

        public string ruleName { get; set; }

        public RuleSeverity severity { get; set; }
    }


    public enum RuleSeverity
    {
        Error = 0,
        Warning = 1,
        Information = 2,
        Success = 3
    }

}
