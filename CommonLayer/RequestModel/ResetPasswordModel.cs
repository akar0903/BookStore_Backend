using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.RequestModel
{
    public class ResetPasswordModel
    {
        public string OldPassword {  get; set; }
        public string NewPassword { get; set; }
    }
}
