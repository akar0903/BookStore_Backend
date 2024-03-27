using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.RequestModel
{
    public class ForgetPasswordModel
    {
        public string EmailId { get; set; }
        public string Id { get; set; }
        public string Token {  get; set; }
    }
}
