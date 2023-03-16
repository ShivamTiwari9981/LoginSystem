using System;
using System.Collections.Generic;

namespace LoginSystemAPI.Models
{
    public partial class TblClaim
    {
        public int ClaimId { get; set; }
        public int RoleId { get; set; }
        public string ClaimDisc { get; set; } = null!;
        public string? Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
