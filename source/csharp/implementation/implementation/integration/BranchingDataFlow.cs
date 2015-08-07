using System;

namespace implementation
{
	public class Checkout_Processor
	{
		public void Checkout(Customer customer) {
			If_Customer_has_credit(customer,
				Checkout_with_credit_card,
				Checkout_with_cash);
		}

		public void If_Customer_has_credit(Customer customer, Action has_credit, Action has_no_credit) {
			if(customer.Balance >= 1000.0) {
				has_credit();
			} else {
				has_no_credit();
			}
		}

		public void Checkout_with_credit_card() {
			// ...
		}

		public void Checkout_with_cash() {
			// ...
		}
	}

	public class Customer
	{
		public string Name { get; set; }

		public double Balance { get; set; }

		// ...
	}
}

