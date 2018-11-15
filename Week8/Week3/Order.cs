using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Week6
{
    public class Order
    {
        private List<OrderDetail> details = new List<OrderDetail>();

        public Order(uint orderId,Customer customer)
        {
            Id = orderId;
            Customer = customer;
        }

        public uint Id { get; set; }

        public Customer Customer { get; set; }

        public double Amount
        {
            get
            {
                return details.Sum(d => d.Goods.Price * d.Quantity);
            }
        }

        public List<OrderDetail>Details
        {
            get => this.details;
        }

        public void AddDetails(OrderDetail orderDetail)
        {
            if(this.Details.Contains(orderDetail))
            {
                throw new Exception($"orderDetails-{orderDetail.Id} is already existed!");
            }
            details.Add(orderDetail);
        }

        public void RemoveDetails(uint orderDetailId)
        {
            details.RemoveAll(d => d.Id == orderDetailId);
        }

        public override string ToString()
        {
            string result = "================================================================================\n";
            result += $"orderId:{Id}, customer:({Customer.Name}),Amount:{Amount}";
            details.ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }

        public bool isMatched(string number,string phoneNumber)
        {
            string pattern = "2[0-9]+\t[0-9]+\t[0-9]+\t[0-9]^3";     //年月日+三位流水号
            string phoneNumTest = "1[0-9]^10";     //电话号码
            if (Regex.IsMatch(number, pattern) && Regex.IsMatch(phoneNumber, phoneNumTest))
                return true;
            else
                return false;
        }
    }
}