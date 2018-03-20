using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyBridgeProject.Domain
{
    class CasePerson
    {
        public string casesId { get; set; }
        public string personId { get; set; }
        public string caseCode { get; set; }
        public string customerCode { get; set; }
        public string customerRelationCode { get; set; }
        public string hierarchyRelationInCase { get; set; }

        public CasePerson(string casesId, string personId, string caseCode, string customerCode, string customerRelationCode, string hierarchyRelationInCase)
        {
            this.casesId = casesId;
            this.personId = personId;
            this.caseCode = caseCode;
            this.customerCode = customerCode;
            this.customerRelationCode = customerRelationCode;
            this.hierarchyRelationInCase = hierarchyRelationInCase;
        }
    }
}
