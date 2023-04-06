using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mp1
{
    internal class Insurance
    {
        private static List<Insurance> insuranceExtent = new();
        private DateTime _expirationDate;
        public DateTime ExpirationDate
        {
            get => _expirationDate;
            set
            {
                if (value < DateTime.Now)
                {
                    throw new Exception("Expiration date cannot be in the past");
                }
                else
                {
                    _expirationDate = value;
                }
            }
        }
        private string _insuranceId;
        public string InsuranceId 
        {
            get => _insuranceId;
            set
            {
                if (insuranceExtent.Any(insurance => insurance.InsuranceId == value))
                {
                    throw new Exception("Insurance ID already exists");
                }
                else if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Insurance ID cannot be null or empty");
                }
                else
                {
                    _insuranceId = value;
                }
            }
        }
    }
}
