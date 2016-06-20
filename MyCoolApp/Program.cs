using System;
using System.Collections.Generic;

using Entity;
using Orm;

namespace MyCoolApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var ctx = new DataContext();

			var ordHeader = ctx.OrderHeaders.Add(new OrderHeader { Created = DateTime.Now} );

			ordHeader.OrderItems = new List<OrderItem>
			{
				new OrderItem {OrderHeader = ordHeader, Price = 10},
				new OrderItem {OrderHeader = ordHeader, Price = 20},
				new OrderItem {OrderHeader = ordHeader, Price = 30}
			};

			ctx.SaveChanges();

			var ordItem = ctx.OrderItems.Find(1);
			ordItem.Price = 15;
			ctx.SaveChanges();
		}
	}
}